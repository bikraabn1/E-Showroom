using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTS.config;

namespace UTS.model
{
    internal class VehiclesModel
    {
        private int _vehicle_id;
        private string _license_plate;
        private int _capacity;
        private string _status;
        private int _type_id;

        Connection server;
        string query;

        public VehiclesModel()
        {
            _vehicle_id = 0;
            _license_plate = "";
            _capacity = 0;
            _status = "";
            _type_id = 0;

            this.query = "";
            this.server = new Connection();
        }

        public int VehicleID
        {
            set { _vehicle_id = value; }
        }
        public string LicensePlate
        {
            set { _license_plate = value; }
        }
        public int Capacity
        {
            set { _capacity = value; }
        }
        public string Status
        {
            set { _status = value; }
        }
        public int TypeID
        {
            set { _type_id = value; }
        }

        public DataTable getVehiclesDatas()
        {
            query = "select * from vehicles";
            return server.queryExecution(query);
        }

        
    }
}
