using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymnastiksalssystem
{
    internal class BookingManager
    {
        List<Booking> bookingList = new List<Booking>();

        //CRUDS
        //CREATE (C) Add
        public void AddBooking(Booking booking)
        {
            bookingList.Add(booking);
        }


        //READ (R) Print
        //Skal kunne printe skemaet for den kommende uge.
        public List<Booking> GetBookingList()
        {
            return bookingList;
        }


        //UPDATE (U) Update
        //Skal kunne hente og opdatere reservationer og ændre på groupName.
        //Group constructor indeholder string groupName, string ageGroup, byte numberOfParticipants
        public void UpdateBooking(int id, string bookingStart, string bookingEnd, int gymHall, string groupName, string ageGroup, byte numberOfParticipants)
        {
            foreach (Booking booking in bookingList)
            {
                if (booking.Id == id)
                {
                    booking.BookingStart = bookingStart;
                    booking.BookingEnd = bookingEnd;
                    booking.GymHall = gymHall;
                    booking.GroupName = groupName;
                    booking.AgeGroup = ageGroup;
                    booking.NumberOfParticipants = numberOfParticipants;

                }

            }
        }

        //DELETE (D) Remove
        //Skal kunne hente og slette reservationer fra bookingListen.
        public void DeleteBooking(Booking booking)
        {
            bookingList.Remove(booking);
        }

        //PRINT listen
        public void PrintBooking()
        {
            foreach (Booking booking in bookingList)
            {
                Console.WriteLine(booking);
            }
        }


        //USER-QUERY        USER-QUERY      USER-QUERY
        public Booking? SearchForReservation(string query)
        {
            foreach (Booking booking in bookingList)
            {
                if (booking.BookingStart == query)
                {
                    return booking;
                }

            }
        }






        //IMPLEMENTATION       IMPLEMENTATION         IMPLEMENTATION
        //CREATE:
        //Skal indeholde if-statement i dur med - same groupName || id in preceding or following timeslot is not equal to succesful booking.
        //Skal indeholde if-statements: hvis tiden allerede er booket ≠ cannot create

        public int ReserveASpot()
        {
            PrintBooking();
            //                             INTROTEKST               INTROTEKST
            Console.WriteLine("Vil du gerne reservere en tid i en af Fritidhjemmet Højens gymnastiksale? " +
                "\n Hvis du vil reservere en dato, tryk 1" +
                "\n Hvis du vil opdatere en reservering, tryk 2" +
                "\n Hvis du vil reservation for et enkelt hold, tryk 3" +
                "\n Hvis du vil slette en reservation, tryk 4" +
                "\n Hvis du vil se alle reservationer endnu en gang, tryk 5");
            string answer = Console.ReadLine();

            try
            {

                if (answer == "1")          //CREATE RESERVATION
                {
                    Console.WriteLine("Skriv reserveringens id");
                    int answerId = Convert.ToInt32(Console.ReadLine()); ;
                    Console.WriteLine("Skriv startstidspunktet for reserveringen - f.eks. 14/06/2024 14:00");
                    string answerBookingStart = Console.ReadLine();
                    Console.WriteLine("Skriv sluttidspunktet for reserveringen - f.eks. 14/06/2024 16:00 OBS: max to timer");
                    string answerBookingEnd = Console.ReadLine();
                    Console.WriteLine("Hvilken gymnastiksal vil de gerne benytte? 1 eller 2?");
                    int answerGymHall = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Skriv navnet på din gruppe");
                    string answerGroupName = Console.ReadLine();
                    Console.WriteLine("Hvilken aldersgruppe er din gruppe?");
                    string answerAgeGroup = Console.ReadLine();
                    Console.WriteLine("Hvor mange deltagere er I?");
                    byte answerNumberOfParticipants = Convert.ToByte(Console.ReadLine());

                    Booking newBooking = new Booking(answerId, answerBookingStart, answerBookingEnd, answerGymHall, answerGroupName, answerAgeGroup, answerNumberOfParticipants);
                    //if-statements her, der kontrollerer om der er dobbeltbookinger
                    foreach (Booking booking in bookingList)

                        if (booking.BookingStart == answerBookingStart)
                        {
                            Console.WriteLine("Denne tid er allerede reserveret.");
                        }
                        else
                        {
                            AddBooking(newBooking);
                        }

                    return 1;
                }

                else if (answer == "2")         //UPDATE        UPDATE      UPDATE
                {
                    Console.WriteLine("Du vil gerne opdatere en reservation:");
                    Console.WriteLine("Skriv reserveringens id");
                    int answerId = Convert.ToInt32(Console.ReadLine()); ;
                    Console.WriteLine("Skriv det nye startstidspunkt for reserveringen - f.eks. 14/06/2024 14:00");
                    string answerBookingStart = Console.ReadLine();
                    Console.WriteLine("Skriv det nye sluttidspunkt for reserveringen - f.eks. 14/06/2024 16:00 OBS: max to timer");
                    string answerBookingEnd = Console.ReadLine();
                    Console.WriteLine("Hvilken gymnastiksal vil de gerne benytte? 1 eller 2?");
                    int answerGymHall = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Skriv navnet på din gruppe");
                    string answerGroupName = Console.ReadLine();
                    Console.WriteLine("Hvilken aldersgruppe er din gruppe?");
                    string answerAgeGroup = Console.ReadLine();
                    Console.WriteLine("Hvor mange deltagere er I?");
                    byte answerNumberOfParticipants = Convert.ToByte(Console.ReadLine());

                    UpdateBooking(answerId, answerBookingStart, answerBookingEnd, answerGymHall, answerGroupName, answerAgeGroup, answerNumberOfParticipants);


                }

                else if (answer == "3")  //QUERY FOR GROUP/TEAM             QUERY FOR GROUP/TEAM
                {



                }

                else if (answer == "4") //DELETE         DELETE          DELETE
                {
                    Console.WriteLine("Vil du gerne slette en tid? Skriv reservationens id:");
                    try
                    {
                        int deleteReservation = Convert.ToInt32(Console.ReadLine());
                        bookingList.RemoveAt(deleteReservation);
                    }
                    catch (Exception ex) { Console.WriteLine("Der var ingen reservation at slette på det indtastede id"); }
                }

                else if (answer == "5") //PRINT RESERVATIONS YET AGAIN
                {
                    PrintBooking();
                }

                else if (answer == "6")
                {

                }
            }
            catch (Exception ex) { Console.WriteLine("Something went wrong, ya!"); return 40; }
            finally
            {Console.WriteLine("Loss of sanity, mental-wellbeing and acuity is not the responsibility of Zealand Ervhervsakademi.");}
        }
    }
}
