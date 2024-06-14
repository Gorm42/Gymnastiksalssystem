using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymnastiksalssystem
{
    internal class Booking
    {
        //Så her har jeg... mine CRUDS? Nej, de skal vel ligge i BookingManager. Sammen med mine lister.
        //Ja, mine CRUDS har brug for de data, som der ligger her - f.eks. alt det her DateTime.

        private string _groupName;
        private string _ageGroup;
        private byte _numberOfParticipants;
        private string _bookingStart;
        private string _bookingEnd;
        private int _gymHall;
        private int _id;

        //constructor
        public Booking(int id, string bookingStart, string bookingEnd, int gymHall, string groupName, string ageGroup, byte numberOfParticipants) 
        {
              _id = id;
              _bookingStart = bookingStart;
              _bookingEnd = bookingEnd;
              _gymHall = gymHall;
              _groupName = groupName;
              _ageGroup = ageGroup;
              _numberOfParticipants = numberOfParticipants;
        }

        //property
        //public DateTime DateOfBooking { get {return dateOfBooking; } }
        public int Id {  get { return _id; } }
        public string BookingStart { get { return _bookingStart; } set {_bookingStart = value ;} }
        public string BookingEnd { get { return _bookingEnd; } set {_bookingEnd = value; } }
        public int GymHall { get {  return _gymHall; } set {_gymHall = value ;} }
        public string GroupName { get { return _groupName; } set { _groupName = value; } }
        public string AgeGroup { get { return _ageGroup; } set { _ageGroup = value; } }
        public byte NumberOfParticipants { get { return _numberOfParticipants; } set { _numberOfParticipants = value; } }

        //ToString
        public override string ToString()
        {
            return _id + ", " +_bookingStart + ", " + _bookingEnd + ", " + _groupName + ", " + _ageGroup + ", " + _numberOfParticipants + ".";
        }
    }
}

