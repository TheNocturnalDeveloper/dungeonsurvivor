using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace DAL
{
    //written by Jake van Hout
    public class MysqlWrapper
    {
        //the connection variable (this will be used to connect tot the database
        private MySqlConnection con;
        //the connection string (this will be used by the connection variable to connect to the database)
        private MySqlConnectionStringBuilder conString = new MySqlConnectionStringBuilder();

        public MysqlWrapper(string a_host, string a_user, string a_password, string a_database)
        {
            //the class constructor 

            //sets the values of the connection string to the values of the parameters of the constructor
            conString.Server = a_host;
            conString.UserID = a_user;
            conString.Password = a_password;
            conString.Database = a_database;

            //sets the value of the connection variable using the connectionstring (true indicates that the password has to be included)
            con = new MySqlConnection(conString.GetConnectionString(true));
        }

        public MysqlWrapper(string connectionString)
        {
            con = new MySqlConnection(connectionString);
        }

        public Table query(MySqlCommand command)
        {
            /*
             * the query function (this function will be used to execute queries)
             * the results of the query will be returned in a list containing fieldList's (a list containing fields, for more info see the field class)
            */

            //this variable will be used to return the results of the query that was executed
            Table m_result = new Table();

            //the connection is opened (if it was closed)
            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();

            //this variable will be used to read the results of the query that was executed
            MySqlDataReader m_reader = command.ExecuteReader();

            //this is a string array that will hold all of the column names
            string[] m_columns = Enumerable.Range(0, m_reader.FieldCount).Select(m_reader.GetName).ToArray();



            //while there are records to read this loop will keep running
            while (m_reader.Read())
            {
                //this variable will hold all the data of a record
                Record m_values = new Record();

                //the code within this loop will be executed for each column in the string array
                foreach (string m_column in m_columns)
                {
                    //an object is created with the column name and value of the current field
                    Field m_field = new Field { key = m_column, value = m_reader[m_column].ToString() };

                    //the object will be added to the object that holds the fields for the current record
                    m_values.Add(m_field);

                }

                //the object with the record will be added to the object that holds all the records
                m_result.Add(m_values);
            }
            //the connection is closed (if it was open)
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();

            //the object with all the records is used as the return value
            return m_result;
        }

        public Table query(string a_query)
        {



            //this variable is used to execute queries (it needs a query and a connection)
            MySqlCommand m_cmd = new MySqlCommand(a_query, con);

            return query(m_cmd);


        }


        //this function returns the connection variable
        public MySqlConnection getConnection() => con;



        //this function returns the connection stringbuilder used to create a connection variable
        public MySqlConnectionStringBuilder getConnectionString() => conString;


        //this function allows you to retrieve a certain field based on the column name (it requires a list<field>)
        public Field getFieldByName(List<Field> a_fieldList, string a_fieldName) => a_fieldList.Find(i => i.key == a_fieldName);


    }


    public class Field
    {
        /*
        * this class is used to store results  returned by queries
        * key : the column name
        * value : the value returned by the query
        */

        public string key { get; set; }
        public string value { get; set; }
    }


    public class Record : List<Field>
    {
        /*
         * field list is a class that inherrits from the list class
         * it contains an extra function to retrieve fields by column name (this version uses the list it is a part of and thus it doesn't require you to pass a list as parameter)  
         */

        public Field getFieldByName(string a_fieldName) => this.Find(i => i.key == a_fieldName);


    }

    public class Table : List<Record>
    {
        public List<T> ConvertTable<T>()
        {
            var fields = typeof(T).GetFields();
            var properties = typeof(T).GetProperties();

            return this.Select(record =>
            {
                T tempT = Activator.CreateInstance<T>();

                foreach (FieldInfo field in fields)
                {
                    if (field.IsDefined(typeof(TableField)))
                    {
                        var fieldString = record.getFieldByName(field.Name).value;

                        if (field.FieldType == typeof(string))
                        {
                            field.SetValue(tempT, fieldString);
                        }
                        else
                        {
                            var converter = TypeDescriptor.GetConverter(field.FieldType);

                            var fieldValue = converter.IsValid(fieldString) ? converter.ConvertFromString(fieldString) : Activator.CreateInstance(field.FieldType);

                            field.SetValue(tempT, fieldValue);
                        }

                    }
                }


                foreach (PropertyInfo property in properties)
                {
                    if (property.IsDefined(typeof(TableField)))
                    {
                        var propertyString = record.getFieldByName(property.Name).value;
                        if (property.PropertyType == typeof(string))
                        {
                            property.SetValue(tempT, propertyString);
                        }
                        else
                        {
                            var converter = TypeDescriptor.GetConverter(property.PropertyType);
                            var propertyValue = converter.IsValid(propertyString) ? converter.ConvertFromString(propertyString) : Activator.CreateInstance(property.PropertyType);
                            property.SetValue(tempT, propertyValue);
                        }
                    }
                }

                return tempT;
            }).ToList();
        }
    }


    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = false)]
    public class TableField : Attribute
    {

    }
}

