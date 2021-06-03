using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NorthwindBAL;
using NorthwindDAL;
using FirstAPI.Models;


namespace FirstAPI.Controllers
{
    public class CustomerController : ApiController
    {
        // GET: api/Customer
        CustomerBAL customerBAL = new CustomerBAL();
        CustomerDAL customerDAL = new CustomerDAL();
        public List<CustomerModel> Get()
        {
            List<CustomerBAL> customerBALs = customerDAL.GetCustomers();

            List<CustomerModel> modelList = new List<CustomerModel>();
            foreach (var item in customerBALs)
            {
                CustomerModel cm = new CustomerModel();
                cm.CustID = item.custID;
                cm.CustName = item.custName;
                cm.CustCity = item.custCity;
                modelList.Add(cm);
            }
            return modelList;
        }

        // GET: api/Customer/5
        public CustomerModel Get(string id)
        {
            CustomerModel cm = new CustomerModel(); 
            customerBAL =customerDAL.GetCustomers(id); 
            cm.CustID = customerBAL.custID;
            cm.CustName=customerBAL.custName; 
            cm.CustCity=customerBAL.custCity;
            return cm;
        }

        // POST: api/Customer
        public void Post([FromBody]CustomerModel value)
        {
            customerBAL.custID = value.CustID;
            customerBAL.custName = value.CustName;
            customerBAL.custCity = value.CustCity;
            customerDAL.AddCustomer(customerBAL);
        }

        // PUT: api/Customer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Customer/5
        public void Delete(int id)
        {
        }
    }
}
