using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ADO.Net_Project.Models;

namespace ADO.Net_Project.Repository
{
	public class EmpRepository
	{
		private SqlConnection con;

	    private void connection()
		{
			String constr = ConfigurationManager.ConnectionStrings["test"].ToString();
			con = new SqlConnection(constr);

		}
		public bool AddEmployee(EmpoyeeModel emp)
		{
			connection();
			SqlCommand com =new SqlCommand("dbo.sp_insertEmpolyee1", con);
			com.CommandType = CommandType.StoredProcedure;
			com.Parameters.AddWithValue("@Emp_Name", emp.Emp_Name);
			com.Parameters.AddWithValue("@Address ", emp.Address);
			com.Parameters.AddWithValue("@Email", emp.Email);
			com.Parameters.AddWithValue("@Salary", emp.Salary);

			con.Open();
			int i = com.ExecuteNonQuery();
			con.Close();
			if(i >= 1)
			{
				return true;
			}
			else
			{
				return false;
			}

		}
	}
}