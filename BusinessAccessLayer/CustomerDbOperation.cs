using CommonLayer.Models;
using DatabaseAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BusinessAccessLayer
{
    public class CustomerDbOperation
    {
        public DbConnect dbConnect;


        public CustomerDbOperation()
        {
            dbConnect = new DbConnect();
        }
        public List<Customer> GetCustomers()
        {
            SqlCommand command = new SqlCommand("sp_customers", dbConnect.connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@action", "select");
            if (dbConnect.connection.State == ConnectionState.Closed) dbConnect.connection.Open();
            SqlDataReader dr = command.ExecuteReader();
            List<Customer> customers = new List<Customer>();
            while (dr.Read())
            {
                Customer obj = new Customer();
                obj.Id = (int)dr["id"];
                obj.Fname = dr["Fname"].ToString();
                obj.Lname = dr["Lname"].ToString();
                obj.Email = dr["Email"].ToString();
                obj.Gender = dr["Gender"].ToString();
                obj.Mobile = dr["Mobile"].ToString();
                obj.Address = dr["Address"].ToString();
                customers.Add(obj);
            }
            dbConnect.connection.Close();
            return customers;

        }
         
        public Customer CreateCustomer(Customer customer)
        {
            SqlCommand command = new SqlCommand("sp_customers", dbConnect.connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@action", "create");
            command.Parameters.AddWithValue("@Fname", customer.Fname);
            command.Parameters.AddWithValue("@Lname", customer.Lname);
            command.Parameters.AddWithValue("@Email", customer.Email);
            command.Parameters.AddWithValue("@Gender", customer.Gender);
            command.Parameters.AddWithValue("@Mobile", customer.Mobile);
            command.Parameters.AddWithValue("@Address", customer.Address);

            if (dbConnect.connection.State == ConnectionState.Closed)
                dbConnect.connection.Open();
            var result = (int)command.ExecuteScalar();
            dbConnect.connection.Close();
            if (result == 1)
            {
                return customer;
            }
            else
            {
                return null;
            }
        }

        public Customer GetCustomerById(int id) 
        {
            SqlCommand command = new SqlCommand("sp_customers", dbConnect.connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@action", "SELECT_SINGLE");
            command.Parameters.AddWithValue("@id", id);
            if (dbConnect.connection.State == ConnectionState.Closed) dbConnect.connection.Open();
            SqlDataReader dr = command.ExecuteReader();
            dr.Read();
            Customer obj = new Customer();
            obj.Fname = dr["Fname"].ToString();
            obj.Fname = dr["Fname"].ToString();
            obj.Lname = dr["Lname"].ToString();
            obj.Email = dr["Email"].ToString();
            obj.Gender = dr["Gender"].ToString();
            obj.Mobile = dr["Mobile"].ToString();
            obj.Address = dr["Address"].ToString();
            dbConnect.connection.Close();
            return obj;
        }

        public bool DeleteCustomer(int id)
        {
            SqlCommand command = new SqlCommand("sp_customers", dbConnect.connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@action", "Delete");
            command.Parameters.AddWithValue("@id", id);
            if (dbConnect.connection.State == ConnectionState.Closed) dbConnect.connection.Open();
            int i = (int)command.ExecuteScalar();

            dbConnect.connection.Close();
            if (i == 1)
                return true;
            else
                return false;

        }



    }
}
