﻿using System;
using System.Data.Entity;

namespace IvyNotesv2.Database
{
    public class Measure
    {
        public int MeasureID { get; set; }
        public DateTime MeasureDT { get; set; }
        public string MeasureComments { get; set; }
        public int MeasureValueHeight { get; set; }
        public int MeasureValueWeight { get; set; }
    }

    public class IvyContext : DbContext
    {
        public IvyContext() : base()
        {

        }

        public DbSet<Measure> Measures { get; set; }
        public DbSet<Diaper> Diapers { get; set; }
        public DbSet<FeedingBottle> FeedingBottles { get; set; }
    }

    public class FeedingBottle
    {
        public int FeedingBottleID { get; set; }
        public DateTime FeedingBottleDT { get; set; }
        public string FeedingBottleType { get; set; }
        public string FeedingBottleComments { get; set; }
        public int FeedingBottleQuantity { get; set; }

    }

    public class Diaper
    {
        public int DiaperID { get; set; }
        public DateTime DiaperDT { get; set; }
        public bool DiaperHasPoop { get; set; }
        public bool DiaperHasPee { get; set; }
        public string DiaperComments { get; set; }
    }
}
