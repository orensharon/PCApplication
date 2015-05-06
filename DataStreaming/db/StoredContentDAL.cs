using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataStreaming.db
{
    class StoredContentDAL
    {
        public const string ConntectString = "Data Source=(localdb)\\Projects;Initial Catalog=SafeDB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";

        public void StoreContact(ContactRequest request)
        {

            string sqlString;
            string result;

            // SQL query
            sqlString = @"SELECT COUNT(*) FROM Contacts WHERE Id=@user_id";

            result = String.Empty;
            using (SqlConnection con = new SqlConnection(ConntectString))
            {
                con.Open();
                // Execute query
                SqlCommand com = new SqlCommand(sqlString, con);
                com.Parameters.AddWithValue("@user_id", request.ID);

                int UserExist = (int)com.ExecuteScalar();
                string query;

                if (UserExist > 0)
                {
                    //Username exist
                    query = @"
                        UPDATE Contacts 
                        SET DisplayName=@name, Phones=@phones, Emails=@emails, Addresses=@addresses, InstantMessengers=@instantMessengers,
                        PhotoURI=@photoURI, Organization=@organization, Notes=@notes
                        WHERE Id=@id";

                }
                else
                {
                    //Username doesn't exist.
                    query = @"
                        INSERT INTO Contacts
                        (Id, DisplayName, Phones, Emails, Addresses, InstantMessengers, PhotoURI, Organization, Notes) 
                        VALUES (@id, @name, @phones, @emails, @addresses, @instantMessengers, @photoURI, @organization, @notes)";

                }



                var phones = String.Join<Phone>(", ", request.Phones.ToArray());
                var emails = String.Join<Email>(", ", request.Emails.ToArray());
                var addresses = String.Join<LivingAddress>(", ", request.Addresses.ToArray());
                var instantMessengers = String.Join<InstantMenssenger>(", ", request.InstantMessengers.ToArray());

                SqlCommand com1 = new SqlCommand(query, con);
                com1.Parameters.AddWithValue("@id", request.ID);
                com1.Parameters.AddWithValue("@name", request.DisplayName);
                com1.Parameters.AddWithValue("@phones", phones);
                com1.Parameters.AddWithValue("@emails", emails);
                com1.Parameters.AddWithValue("@addresses", addresses);
                com1.Parameters.AddWithValue("@instantMessengers", instantMessengers);
                com1.Parameters.AddWithValue("@photoURI", request.PhotoURI);
                com1.Parameters.AddWithValue("@organization", request.Organization.ToString());
                com1.Parameters.AddWithValue("@notes", request.Notes);

                com1.ExecuteNonQuery();
            }
        }

        public void StorePhoto(string id, string filename)
        {
            string sqlString;
            string result;

            // SQL query
            sqlString = @"SELECT COUNT(*) FROM Photos WHERE Id=@id";

            result = String.Empty;
            using (SqlConnection con = new SqlConnection(ConntectString))
            {
                con.Open();
                // Execute query
                SqlCommand com = new SqlCommand(sqlString, con);
                com.Parameters.AddWithValue("@id", id);

                int contentExists = (int)com.ExecuteScalar();
                string query;

                if (contentExists > 0)
                {
                    //Photo exist
                    query = @"
                        UPDATE Photos 
                        SET FileName=@filename
                        WHERE Id=@id";

                }
                else
                {
                    //Photo doesn't exist.
                    query = @"
                        INSERT INTO Photos
                        (Id, FileName) 
                        VALUES (@id, @filename)";

                }

                SqlCommand com1 = new SqlCommand(query, con);
                com1.Parameters.AddWithValue("@id", id);
                com1.Parameters.AddWithValue("@filename", filename);
                com1.ExecuteNonQuery();
            }
        }





        public ContactRequest GetContact(string id)
        {
            string sqlString;
            ContactRequest result = null;

            // SQL query

            sqlString = @"SELECT * FROM Contacts WHERE Id=@id";
            using (SqlConnection con = new SqlConnection(ConntectString))
            {
                con.Open();
                // Execute query
                SqlCommand com = new SqlCommand(sqlString, con);
                com.Parameters.AddWithValue("@id", id);

                using (SqlDataReader reader = com.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = new ContactRequest();
                        result.ID = reader.GetString(0);
                        result.DisplayName = reader.GetString(1);
                    }
                    reader.Close();
                }
                
            }

            return result;

        }

    }
}
