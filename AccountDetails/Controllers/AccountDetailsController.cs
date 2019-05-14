using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AccountDetails.Models;

namespace AccountDetails.Controllers
{
    public class AccountDetailsController : Controller
    {
        // GET: AccountDetails
        public ActionResult Index()
        {
            using (AccountDetailsDbEntities accountdetails = new AccountDetailsDbEntities())
            {

                return View();
            }
        }

        // GET: AccountDetails/Details/5
        public ActionResult Details(int id)
        {
            using (AccountDetailsDbEntities accountDetailsDbEntities = new AccountDetailsDbEntities())
            {

                return View(accountDetailsDbEntities.AccountDetailsTables.Where(x => x.accountNumber == id).FirstOrDefault());
            }
        }

        // GET: AccountDetails/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: AccountDetails/Create
        [HttpPost]
        public ActionResult Create(AccountDetailsTable accountDetailsTable)
        {
            try
            {
                // TODO: Add insert logic here
                using (AccountDetailsDbEntities accountDetailsDbEntities = new AccountDetailsDbEntities())
                {
                    accountDetailsDbEntities.AccountDetailsTables.Add(accountDetailsTable);
                    accountDetailsDbEntities.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountDetails/Edit/5
        public ActionResult Edit(int id)
        {
            using (AccountDetailsDbEntities accountDetailsDbEntities = new AccountDetailsDbEntities())
            {
                return View(accountDetailsDbEntities.AccountDetailsTables.Where(x=>x.accountNumber==id).FirstOrDefault());
            }
        }

        // POST: AccountDetails/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, AccountDetailsTable accountDetailsTable)
        {
            try
            {
                using (AccountDetailsDbEntities accountDetailsDbEntities = new AccountDetailsDbEntities())
                {
                    accountDetailsDbEntities.Entry(accountDetailsTable).State = EntityState.Modified;
                    accountDetailsDbEntities.SaveChanges();

                }
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountDetails/Delete/5
        public ActionResult Delete(int id)
        {
            // using (AccountDetailsDbEntities accountDetailsDbEntities = new AccountDetailsDbEntities())
            // {
            //    return View(accountDetailsDbEntities.AccountDetailsTables.Where(x => x.accountNumber == id).FirstOrDefault());
            //}
            return View();
        }

        // POST: AccountDetails/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, AccountDetailsTable accountDetailsTable)
        {
            try
            {
                
                    // TODO: Add delete logic here

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
