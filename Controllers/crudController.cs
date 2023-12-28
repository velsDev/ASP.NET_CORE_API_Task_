using API_Task_dec28.Model;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Task_dec28.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class crudController : ControllerBase
    {
        string constr = "Data Source=VELSS\\SQLEXPRESS;Initial Catalog = API_TasK_dec28 ; Integrated Security = True ";  // Connection String

        // GET: api/<crudController>
        [HttpGet]
        public List <crud> Get()   // FETCH
        {
            List<crud> obj = new List<crud>();
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            SqlCommand cmd = new SqlCommand("sp_fetch",con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                obj.Add(new crud
                {
                    id = Convert.ToInt32(reader["id"]),
                    state = Convert.ToString(reader["state"]),
                    city = Convert.ToString(reader["city"]),
                    pincode = Convert.ToString(reader["pincode"])
                }
                   );
            }


            

            return obj;
        }

        // GET api/<crudController>/5
        [HttpGet("{id}")]
        public crud Get(int id)       // FETCH BY ID 
        {
            crud obj1 = new crud();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "sp_fetch_id " + id ;
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                obj1 = new crud

                {
                    id = Convert.ToInt32(reader["id"]),
                    state = Convert.ToString(reader["state"]),
                    city = Convert.ToString(reader["city"]),
                    pincode = Convert.ToString(reader["pincode"])
                };
                  
            }



            con.Close();
            return obj1;
            
        }

        // POST api/<crudController>
        [HttpPost]
        public void Post(crud obj1)      //POST
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "sp_insert ' " + obj1.state + " ' , ' " + obj1.city + " ',' " + obj1.pincode + " ' ";
            SqlCommand cmd = new SqlCommand(query,con);
            cmd.ExecuteNonQuery();
            con.Close() ;
        }

        // PUT api/<crudController>/5 
        [HttpPut("{id}")]
        public void Put(int id, crud obj1)   //PUT
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "sp_update " + id  + " , ' " + obj1.state + " ' , ' " + obj1.city + " ',' " + obj1.pincode + " ' " ;
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // DELETE api/<crudController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)          //DELETE
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "sp_delete " + id;
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
