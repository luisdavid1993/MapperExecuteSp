//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Configuration.Provider;
//using System.Data;
//using System.Data.SqlClient;
//using System.Reflection;
//using System.Data.Common;
//using System.Data.Linq.Mapping;
//using System.Linq;


using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Reflection;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Configuration.Provider;
using Tier.Data.Utiles;

namespace Tier.Data
{
   public class BaseDTO<T>
    {
        protected List<SqlParameter> parametros = new List<SqlParameter>();
        protected internal SqlCommand command;
        protected internal SqlConnection connection;
        /// <summary>
        /// Get The connection string, for the connection to the database
        /// </summary>
        /// <returns></returns>
        /// 
        protected static string GetConnectionString()
        {
            try{ return ConfigurationDTO.ConnectionString;}
            catch (ProviderException ex)
            {
                throw new ProviderException("Error al recuperar el string de conexión a la BD. Verifique que la conexión exista en el archivo de configuración.", ex);
            }
            catch (Exception ex)
            {
                throw new ProviderException("Error al recuperar el string de conexión a la BD.", ex);
            }
            
        }


        /// <summary>
        /// Execute a store procedure that return a Datareader, this Datareader is Mapper to the generict List
        /// </summary>
        /// <param name="ProcedureName"> Name of Procedure </param>
        /// <param name="objeto"> Object to pass into the procedure </param>
        /// <returns> Generic List  </returns>
        protected Collection<T> ExuecuteProcedure(string ProcedureName)
        {
            command = null;
            SqlDataReader dataReader = null;
            try {

                connection = new SqlConnection(GetConnectionString());
                command = new SqlCommand(ProcedureName, connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                if (parametros != null) { foreach (SqlParameter item in parametros) { command.Parameters.Add(item); } }
                dataReader = command.ExecuteReader();
                return (dataReader.HasRows) ? this.MapFromDataReader(dataReader) : null;
            }
            catch (Exception ex){
                throw ex;
            }
            finally{
                command.Dispose();
                if(!dataReader.IsClosed)
                    dataReader.Dispose();
                
                connection.Close();
                connection.Dispose();
            }
        }

     

        /// <summary>
        /// Execute a Store Procedure that not return a value
        /// </summary>
        /// <returns></returns>
        protected bool ExecuteNonQueryBase(string ProcedureName)
        {
           Boolean Result = false;
            command = null;
            try
            {
                connection = new SqlConnection(GetConnectionString());
                command = new SqlCommand(ProcedureName, connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                if (parametros != null) { foreach (SqlParameter item in parametros) { command.Parameters.Add(item); } }
                command.ExecuteNonQuery();
                Result = true;
                return Result;
            }
            catch (Exception ex){
                throw ex;
            }
            finally{
                command.Dispose();
                connection.Close();
                connection.Dispose();
            }
        }




        /// <summary>
        ///  Add the parameters to the Store Procedure
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        /// 
        protected void AddParameters(string name,SqlDbType type , object value) {
            SqlParameter NewParameter = new SqlParameter(name, value);
            NewParameter.SqlDbType = type;
            parametros.Add(NewParameter);
        }


        #region nuevo mapeo


        protected Dictionary<MemberInfo, string> PropertiesToColumnsNames { get; set; }


        /// <summary>
        /// Current object type working
        /// </summary>
        protected Type CurrentType { get; set; }


        /// <summary>
        /// Variable to indicate if working with inheritance
        /// </summary>
        protected bool WorkWithInheredMembers { get { return true; } }



        /// <summary>
        /// Delegates to search criteria.
        /// </summary>
        /// <param name="objMemberInfo">The obj member info.</param>
        /// <param name="objSearch">The obj search.</param>
        /// <returns></returns>
        private bool DelegateToSearchCriteria(MemberInfo objMemberInfo, Object objSearch)
        {
            object[] attributes = objMemberInfo.GetCustomAttributes(typeof(ColumnAttribute), WorkWithInheredMembers);
            if (attributes.Length > 0)
            {
                var dbItemInfo = (ColumnAttribute)attributes[0];
                if (!PropertiesToColumnsNames.ContainsKey(objMemberInfo))
                    PropertiesToColumnsNames.Add(objMemberInfo, dbItemInfo.Name);
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Finds the column names.
        /// </summary>
        /// <param name="type">The type.</param>
        protected void FindColumnNames(Type type)
        {
            BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            if (!WorkWithInheredMembers)
                bindingFlags = bindingFlags | BindingFlags.DeclaredOnly;
            PropertiesToColumnsNames = new Dictionary<MemberInfo, string>();
            type.FindMembers(MemberTypes.Property, bindingFlags, DelegateToSearchCriteria, null);

        }

        /// <summary>
        /// Converts the type of the value to.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="targetType">Type of the target.</param>
        /// <returns></returns>
        protected object ConvertValueToType(object value, Type targetType)
        {
            return DatosBase.ConvertValueToType(value, targetType);

        }

        /// <summary>
        /// Maps from data reader.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader">The reader.</param>
        /// <param name="closeReader">if set to <c>true</c> [close reader].</param>
        /// <returns></returns>
        protected Collection<T> MapFromDataReader(IDataReader reader, bool closeReader)
        {
            try
            {
                Type newType = typeof(T);
                if (CurrentType != newType)
                {
                    CurrentType = newType;
                    FindColumnNames(CurrentType);
                }

                Collection<T> returnList = new Collection<T>();
                object[] values = new object[reader.FieldCount];
                Dictionary<string, int> columnsIds = new Dictionary<string, int>(reader.FieldCount);
                Collection<string> schemaFieldsName = null;
                while (reader.Read())
                {
                    reader.GetValues(values);

                    T objTarget = Activator.CreateInstance<T>();
                    if (schemaFieldsName == null)
                        using (DataTable dtSchema = reader.GetSchemaTable())
                        {
                            schemaFieldsName = new Collection<string>(dtSchema.AsEnumerable().Select(x => x.Field<string>("ColumnName").ToUpper()).ToList());
                        }


                    PropertiesToColumnsNames.Keys.ToList().ForEach((c) =>
                    {

                        string columnName = PropertiesToColumnsNames[c];
                        if (schemaFieldsName.Contains(columnName.ToUpper()))
                        {
                            int columnId = 0;
                            if (columnsIds.ContainsKey(columnName))
                                columnId = columnsIds[columnName];
                            else
                            {
                                columnId = reader.GetOrdinal(columnName);
                                columnsIds.Add(columnName, columnId);
                            }
                            PropertyInfo pMember = (PropertyInfo)c;
                            object value;
                            try
                            { value = ConvertValueToType(values[columnId], pMember.PropertyType); }
                            catch { value = values[columnId]; }
                            pMember.SetValue(objTarget, value, null);
                        }

                    });

                    returnList.Add(objTarget);
                }
                if (closeReader)
                    reader.Dispose();
                return returnList.Count > 0 ? returnList : null;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (!reader.IsClosed)
                    reader.Close();
                reader.Dispose();
            }
        }

        /// <summary>
        /// Maps from data reader.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader">The reader.</param>
        /// <returns></returns>
        protected Collection<T> MapFromDataReader(IDataReader reader)
        {
            return MapFromDataReader(reader, true);
        }


        #endregion

    }
}
