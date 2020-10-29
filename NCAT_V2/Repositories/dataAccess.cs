using MySql.Data.MySqlClient;
using NCAT_V2.Models;
using System;
using System.Collections.Generic;
using System.Data;


namespace NCAT_V2.Repositories
{
    public class dataAccess
    {
        String connString = "SERVER=localhost;Port=4406;DATABASE=ncatbank;UID=root;PASSWORD=@Rupeshkr01";
        public dataAccess()
        {
            MySqlConnection mysql = new MySqlConnection(connString);
            MySqlCommand cmd = new MySqlCommand("select ssn,firstName from ncatbank.customer", mysql);

            mysql.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            var customers = new List<Customer>();
            var customer = new Customer();
            foreach(DataRow item in dt.Rows)
            {
                customer.firstName = item[1].ToString();
                customer.ssn = item[0].ToString();
                customers.Add(customer);
                //customers.Add(item.ItemArray.GetValue("ssn");
            }
            mysql.Close();
        }
    }
}