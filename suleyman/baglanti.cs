using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;

namespace suleyman
{

    /////////////////////////////////////////////////////////////////////////
    public class baglanti
    {


        //connect
        public void makeconnect(SqlConnection ctx)
        {
            string words = "Data Source=.;Initial Catalog=database1;Integrated Security=true;";
            ctx = new SqlConnection(words);
            if (ctx.State == System.Data.ConnectionState.Closed)
                ctx.Open();

        }

        //add
        public void AddUser(string name, string surname, bool gender, DateTime dateofbirth, string phonenumber, int country_Id, int d_id, int a_id, string username, string password)
        {
            
            SqlConnection ctx = new SqlConnection();
            string words = "Data Source=.;Initial Catalog=database1;Integrated Security=true;";
            ctx = new SqlConnection(words);
            if (ctx.State == System.Data.ConnectionState.Closed)
                ctx.Open();

           
            

            SqlCommand komut = new SqlCommand("INSERT INTO User1(Name,Surname,Gender,DateOfBirth,PhoneNumber,Country_Id,Department_Id,Authority_Id,Username,Password) VALUES(@name,@surname,@gender,@dateofbirth,@phonenumber,@country_id,@d_id,@a_id,@username,@password)", ctx);
            komut.Parameters.AddWithValue("@name", name);
            komut.Parameters.AddWithValue("@surname", surname);
            if (gender == true)
            {
                komut.Parameters.AddWithValue("@gender", "Male");
            }
            else if (gender == false)
            {
                komut.Parameters.AddWithValue("@gender", "Female");
            }
            komut.Parameters.AddWithValue("@dateofbirth", dateofbirth);
            komut.Parameters.AddWithValue("@phonenumber", phonenumber);
            komut.Parameters.AddWithValue("@country_id", country_Id);

            komut.Parameters.AddWithValue("@d_id", d_id);
            komut.Parameters.AddWithValue("@a_id", a_id);
            
            komut.Parameters.AddWithValue("@username", username);
            komut.Parameters.AddWithValue("@password", password);
            komut.ExecuteNonQuery();
            


        }
        public void Add_FingerPrint(String UserName, string Data)
        {
            SqlConnection ctx = new SqlConnection();
            string words = "Data Source=.;Initial Catalog=database1;Integrated Security=true;";
            ctx = new SqlConnection(words);
            if (ctx.State == System.Data.ConnectionState.Closed)
                ctx.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO FingerPrint(User1_UserName,Data) VALUES(@username,@data)", ctx);

            komut.Parameters.AddWithValue("@username", UserName);
            komut.Parameters.AddWithValue("@data", Data);
            komut.ExecuteNonQuery();
        }

        //hash hash hash
        public static string Hash222(string password)
        {
            byte[] encodedPassword = new UTF8Encoding().GetBytes(password);

            byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);

            string encoded = BitConverter.ToString(hash)
               .Replace("-", string.Empty)
               .ToLower();

            return encoded;
        }

        //delete
            //Delete user..
        public void Delete_User(string key)
        {
            database1Entities ctx = new database1Entities();
            
            try
            {
                var y = ctx.FingerPrints.Where(w => w.User1_UserName == key);
                ctx.FingerPrints.RemoveRange(y);
                ctx.SaveChanges();
            }
            catch
            {}
            try
            {
                var x = ctx.User1.Where(z => z.UserName == key).FirstOrDefault();
                ctx.User1.Remove(x);
                ctx.SaveChanges();
            }
            catch
            {}
        }
            //Delete Finger..
        public void Delete_FingerPrint(string key)
        {
            database1Entities ctx = new database1Entities();
            try
            {
                var y = ctx.FingerPrints.Where(w => w.Data == key).FirstOrDefault();
                if (y != null)
                {
                    ctx.FingerPrints.Remove(y);
                    ctx.SaveChanges();
                }
            }
            catch
            {}
        }
            //Delete Department..
        public void Delete_Department(string key)
        { 
            database1Entities ctx = new database1Entities();
            try
            {
                var y = ctx.Departments .Where(w => w.Department1 == key).FirstOrDefault();
                if (y != null)
                {
                    y.Status = "Closed";
                    ctx.SaveChanges();
                }
            }
            catch
            { }
        }
       
        
        //List columns
        public DataTable ListUsers()
        {
            SqlConnection baglanti = new SqlConnection("Data Source=.;Initial Catalog=database1;Integrated Security=true;");
            if (Main.yetki == 0)
            {
                SqlCommand komut = new SqlCommand("SELECT User1.Name,Surname,Gender,DateOfBirth[Date Of Birth],PhoneNumber[Phone Number],Country.CountryName[City],Department.Department,Username,Password FROM User1 INNER JOIN Department ON User1.Department_Id = Department.Id INNER JOIN Country ON User1.Country_Id = Country.Id where Authority_Id=1", baglanti);
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                SqlDataReader oku = komut.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(oku);
                return table;
            }
            else if(Main.yetki==99)
            {
                SqlCommand komut = new SqlCommand("SELECT Authority.Authority,User1.Name,Surname,Gender,DateOfBirth[Date Of Birth],PhoneNumber[Phone Number],Country.CountryName[City],Department.Department,Username,Password FROM User1 INNER JOIN Department ON User1.Department_Id = Department.Id INNER JOIN Country ON User1.Country_Id = Country.Id INNER JOIN Authority  ON User1.Authority_Id = Authority.Id where (Authority_Id=1 or Authority_Id=0) ORDER BY Authority.Authority", baglanti);
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                SqlDataReader oku = komut.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(oku);
                return table;
            }
            else
            {
                return null;
            }


        }
        public DataTable ListDepartment()
        {
            SqlConnection baglanti = new SqlConnection("Data Source=.;Initial Catalog=database1;Integrated Security=true;");
            SqlCommand komut = new SqlCommand("SELECT Department, (select count(Department_ID) from User1 where User1.Department_Id=Department.Id) AS 'NUMBER OF USERS' FROM Department where status='Open'", baglanti);
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            SqlDataReader oku = komut.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(oku);
            return table;
        }
        public DataTable ListFingers()
        {
            SqlConnection baglanti = new SqlConnection("Data Source=.;Initial Catalog=database1;Integrated Security=true;");
            if (Main.yetki == 0)
            {
                SqlCommand komut = new SqlCommand("SELECT User1.Name, User1.Surname, FingerPrint.Data[DATA] FROM FingerPrint inner JOIN User1 ON FingerPrint.User1_UserName = User1.UserName where Authority_Id=1 ", baglanti);
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                SqlDataReader oku = komut.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(oku);
                return table;
            }
            else if(Main.yetki==99)
            {
                SqlCommand komut = new SqlCommand("SELECT User1.Name, User1.Surname,Authority.Authority, FingerPrint.Data FROM User1 inner JOIN Authority ON user1.Authority_Id=Authority.Id inner JOIN FingerPrint ON FingerPrint.User1_UserName = User1.UserName where (user1.Authority_Id=0 or user1.Authority_Id=1)  ", baglanti);
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                SqlDataReader oku = komut.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(oku);
                return table;
            }
            else
            {
                return null;
            }
           
        }
        public DataTable ListAdmins()
        {
            SqlConnection baglanti = new SqlConnection("Data Source=.;Initial Catalog=database1;Integrated Security=true;");
            SqlCommand komut = new SqlCommand("select Name,Surname,UserName from User1 where Authority_Id=0", baglanti);
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            SqlDataReader oku = komut.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(oku);
            return table;
        }
        
        //Search columns
        public DataTable SearchUser(string a)
        {
            
            string baglanticumle = "Data Source=.;Initial Catalog=database1;Integrated Security=true;";
            SqlConnection baglanti = new SqlConnection(baglanticumle);
            if (Main.yetki == 0)
            {
                SqlCommand komut = new SqlCommand("SELECT User1.Name,Surname,Gender,DateOfBirth[Date Of Birth],PhoneNumber[Phone Number],Country.CountryName[City],Department.Department,Username,Password FROM User1 INNER JOIN Department ON User1.Department_Id = Department.Id INNER JOIN Country ON User1.Country_Id = Country.Id where Authority_Id=1 and (User1.Name like'" + a + "%' or Surname like'" + a + "%')", baglanti);
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                SqlDataReader oku = komut.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(oku);
                return table;
            }
            else if(Main.yetki == 99)
            {
                SqlCommand komut = new SqlCommand("SELECT Authority.Authority,User1.Name,Surname,Gender,DateOfBirth[Date Of Birth],PhoneNumber[Phone Number],Country.CountryName[City],Department.Department,Username,Password FROM User1 INNER JOIN Department ON User1.Department_Id = Department.Id INNER JOIN Country ON User1.Country_Id = Country.Id INNER JOIN Authority  ON User1.Authority_Id = Authority.Id where (Authority_Id=1 or Authority_Id=0) and (User1.Name like'" + a + "%' or Surname like'" + a + "%') ORDER BY Authority.Authority", baglanti);
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                SqlDataReader oku = komut.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(oku);
                return table;
            }
            else
            {
                return null;
            }



        }
        public DataTable SearchFinger(string a)
        {
            string searchcumle;
            if(Main.yetki == 0)
            {
                searchcumle = "SELECT User1.Name, User1.Surname, FingerPrint.Data FROM FingerPrint inner JOIN User1 ON FingerPrint.User1_UserName = User1.UserName where Authority_Id = 1 and (User1.Name like'" + a + "%' or Surname like'" + a + "%')";
            }
            else if(Main.yetki == 99)
            {
                searchcumle = "SELECT User1.Name, User1.Surname,Authority.Authority, FingerPrint.Data FROM User1 inner JOIN Authority ON User1.Authority_Id=Authority.Id inner JOIN FingerPrint ON FingerPrint.User1_UserName = User1.UserName where (User1.Authority_Id=0 or User1.Authority_Id=1) and (User1.Name like'" + a + "%' or User1.Surname like'" + a + "%')";
            }
            else
            {
                searchcumle = "";
            }

            string baglanticumle = "Data Source=.;Initial Catalog=database1;Integrated Security=true;";
            SqlConnection baglanti = new SqlConnection(baglanticumle);
            SqlCommand komut = new SqlCommand(searchcumle, baglanti);
            if (baglanti.State == ConnectionState.Closed)
               baglanti.Open();
            SqlDataReader oku = komut.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(oku);
            return table;
            
        }
        public DataTable SearchDepartment(string a)
        {

            string baglanticumle = "Data Source=.;Initial Catalog=database1;Integrated Security=true;";
            SqlConnection baglanti = new SqlConnection(baglanticumle);
            SqlCommand komut = new SqlCommand("SELECT Department, (select count(Department_ID) from User1 where User1.Department_Id=Department.Id) AS 'PERSONEL NAME' FROM Department where Status='Open' and Department like '"+a+"%' ", baglanti);
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            SqlDataReader oku = komut.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(oku);
            return table;


        }
        public DataTable SearchAdmin(string a)
        {
            SqlConnection baglanti = new SqlConnection("Data Source=.;Initial Catalog=database1;Integrated Security=true;");
            SqlCommand komut = new SqlCommand("select Name,Surname,UserName from User1 where Authority_Id=0 and (Name like'" + a + "%' or Surname like'" + a + "%' or Username like'" + a + "%')", baglanti);
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            SqlDataReader oku = komut.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(oku);
            return table;
        }
        
        
        ///Fill combobox with what ever u want
        public SqlDataReader FillComboBox(string tablename)     
        {
            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = "Data Source=.;Initial Catalog=database1;Integrated Security=true";
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "SELECT *FROM "+tablename+"";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;

            SqlDataReader dr;
            baglanti.Open();
            dr = komut.ExecuteReader();
            return (dr);
        }

        /////////////////////////////////////////////////////////////////////////
    }
}
