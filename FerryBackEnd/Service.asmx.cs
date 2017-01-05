using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using FerryContract;
using DTO;
using DTO.FerryContract;
using System.Data.SqlClient;
using System.Data;

namespace FerryBackEnd
{
    /// <summary>
    /// Summary description for Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service : System.Web.Services.WebService, CommonInterface
    {

        [WebMethod]
        public List<DTO.FerryContract.Route> GetRoutes()
        {
            var dbcontext = new DBContext();
            var routes = dbcontext.Routes.ToList();
            List<DTO.FerryContract.Route> DTORoutes = new List<DTO.FerryContract.Route>();
            foreach (var route in routes)
            {
                DTORoutes.Add(new DTO.FerryContract.Route(route.Origin, route.Destination, route.Duration));
            }
            return DTORoutes;
        }
       
        [WebMethod]
        public bool MakeReservation(List<DTO.FerryContract.Ticket> tickets)
        {
            int rowsaffected = 0;
            var reservation = new DTO.FerryContract.Reservation();
            // For test purposes.
            Random r = new Random();
            reservation.ID = r.Next(2,9999);
            try
            {
                //create  object  of Connection Class
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString);

                // Open Connection
                con.Open();

                //Create object of Command Class.
                SqlCommand cmd = new SqlCommand();

                //set Connection Property  of  Command object.
                cmd.Connection = con;


                cmd.CommandType = CommandType.Text;
                cmd.CommandText = string.Format("Insert into [dbo].Reservation (ID,Customer,ReservationNumber,HasArrived) values({0},1,{1}, false)", reservation.ID,reservation.ReservationNumber);
                //Set Command text Property of command object

                rowsaffected += cmd.ExecuteNonQuery();
                con.Close();

          
            }
            catch (Exception ex)
            {
                throw;
            }
            foreach (var ticket in tickets)
            {
                try
                {
                    //create  object  of Connection Class
                    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString);

                    // Open Connection
                    con.Open();

                    //Create object of Command Class.
                    SqlCommand cmd = new SqlCommand();

                    //set Connection Property  of  Command object.
                    cmd.Connection = con;


                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = string.Format("Insert into [dbo].Ticket (ID,Price,Reservation,Route) values({0},{1},{2})",ticket.ID,ticket.Price,ticket.Route);
                    //Set Command text Property of command object

                    rowsaffected += cmd.ExecuteNonQuery();
                    con.Close();

                    
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            if (rowsaffected>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddDeparture(DTO.FerryContract.Ferry ferry, DateTime DateAndTime)
        {
            throw new NotImplementedException();
        }

        public bool ChangeFerryForDeparture(DTO.FerryContract.Departure departure, DTO.FerryContract.Ferry newFerry)
        {
            throw new NotImplementedException();
        }

        public bool CheckOutReserveFerry(DTO.FerryContract.Ferry ferry)
        {
            throw new NotImplementedException();
        }

        public bool CreateAccount(bool isLocal, string username, string password, string email)
        {
            throw new NotImplementedException();
        }

        public bool CreateFerry(string name, int peopleCapacity, int vehicleCapacity, int weightCapacityInKg, bool isReserve)
        {
            throw new NotImplementedException();
        }

        public bool CreateRoute(DTO.FerryContract.Departure departure, string destination, TimeSpan duration)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAccount(DTO.FerryContract.Customer customer)
        {
            throw new NotImplementedException();
        }

        public bool DeleteDeparture(DTO.FerryContract.Departure departure)
        {
            throw new NotImplementedException();
        }

        public bool DeleteFerry(DTO.FerryContract.Ferry ferry)
        {
            throw new NotImplementedException();
        }

        public bool DeleteReservation(DTO.FerryContract.Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public bool DeleteRoute(DTO.FerryContract.Route route)
        {
            throw new NotImplementedException();
        }

        public List<DTO.FerryContract.Ferry> GetReserveFerries(int minimumPeopleCapacity, int minimumVehicleCapacity, int minimumWeightCapacity)
        {
            throw new NotImplementedException();
        }


    }
}
