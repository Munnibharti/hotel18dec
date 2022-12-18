using Hotel_Management_Project.DAL;
using Hotel_Management_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel_Management_Project.Controllers
{
            public class ReservationController : Controller
            {
                // GET: Reservation
                // GET: Reservation
                private ReservationRepository reservationrepository;
                public ReservationController()
                {
                    reservationrepository = new ReservationRepository(new Models.DataContext());



                }
                public ActionResult Index()
                {
                    var model = reservationrepository.GetAllReservation();
                    return View(model);
                }





                // GET: Reservation/Create
                public ActionResult Create()
                {
                    DataContext db = new DataContext();



                    var RoomType = db.Rooms.ToList();
                    ViewBag.Room_Type = new SelectList(RoomType, "room_id", "RoomTypes");



                    var Recep_Name = db.ReceptionistAccounts.ToList();
                    ViewBag.Recep_Name = new SelectList(Recep_Name, "rec_id", "emp_name");



                    var Guestname = db.Guests.ToList();
                    ViewBag.Guest_Name = new SelectList(Guestname, "guest_id", "guest_name");
                    return View();
                }



                // POST: Reservation/Create
                [HttpPost]
                public ActionResult Create(Reservation collection)
                {
                    try
                    {
                        // TODO: Add insert logic here
                      
                        
                             reservationrepository.AddReservation(collection);

                TempData["ReservationSuccessfully"] = "<script>('Room is reserved successfully')</script>";
                                return RedirectToAction("Index", "Reservation");
                           
                            
                           
                    }
                    catch
                    {
                        return View();
                    }
                }



                // GET: Reservation/Edit/5
                public ActionResult Edit(int id)
                {
                    Reservation model = reservationrepository.GetReservationById(id);
                    return View(model);
                }



                // POST: Reservation/Edit/5
                [HttpPost]
                public ActionResult Edit(Reservation collection)
                {
                    try
                    {
                        // TODO: Add update logic here
                
                
                            reservationrepository.UpdateReservation(collection);
                    
                    
                                return RedirectToAction("Index", "Reservation");
                    
                    
                    
                              
                    
                        }



              



            





                    catch
                    {
                        return View();
                    }
                }



                // GET: Reservation/Delete/5
                public ActionResult Delete(int id)
                {
                    reservationrepository.GetReservationById(id);
                    return RedirectToAction("Index", "Reservation");
                }



                // POST: Reservation/Delete/5
                [HttpPost]
                public ActionResult Delete(Reservation collection)
                {



                    try
                    {
                        // TODO: Add delete logic here
               
                

                            reservationrepository.DeleteReservation(collection.reservation_id);
                            return RedirectToAction("Index", "Reservation");
                
                



                    }
                    catch
                    {
                        return View();
                    }
                }
    
        

      
      
        
            }
        }
