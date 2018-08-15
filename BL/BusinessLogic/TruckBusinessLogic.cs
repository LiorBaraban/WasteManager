﻿using DAL;
using FND;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class TruckBusinessLogic : BaseBusinessLogic
    {
        public TruckBusinessLogic()
        {
            this.db = new WasteManagerEntities();
        }

        public TruckBusinessLogic(WasteManagerEntities db) : base(db)
        {

        }

        // TRUCK - CRUD 

        public List<Truck> GetAllTrucks()
        {
            try
            {
                return this.db.Trucks.ToList();
            }
            catch (Exception ex)
            {
                throw ErrorHandler.Handle(ex, this);
            }
        }

        public Truck GetTruck(int id)
        {
            try
            {
                return this.db.Trucks.Where(x => x.TruckId == id).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ErrorHandler.Handle(ex, this);
            }
        }

        public Truck AddNewTruck(Truck newTruck)
        {
            try
            {
                this.db.Trucks.Add(newTruck);
                this.db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ErrorHandler.Handle(ex, this);
            }

            return newTruck;
        }

        public void UpdateTruck(Truck updatedTruck)
        {
            try
            {
                Truck truck = this.db.Trucks.Where(x => x.TruckId == updatedTruck.TruckId).SingleOrDefault();
                if (truck != null)
                {
                    truck = updatedTruck;
                }
                this.db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ErrorHandler.Handle(ex, this);
            }
        }

        public void DeleteTruck(int id)
        {
            try
            {
                Truck truck = this.db.Trucks.Where(x => x.TruckId == id).SingleOrDefault();
                this.db.Trucks.Remove(truck);
                this.db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ErrorHandler.Handle(ex, this);
            }
        }

        public void ClearingBins(List<Bin> binList, int truckId, DateTime currentDateTime)  //Go over all the bins and unloading them.
        {
            try
            {
                Truck truck = GetTruck(truckId);

                foreach(Bin bin in binList)
                {
                    double transferredCapacity = bin.CurrentCapacity;
                    truck.CurrentCapacity += transferredCapacity;
                    this.UpdateTruck(truck);

                    bin.CurrentCapacity = 0;
                    using (BinBusinessLogic binBl = new BinBusinessLogic(this.db))
                    {
                        binBl.UpdateBin(bin, currentDateTime);
                    }

                    AddWasteTransferLog(truck.TruckId, bin.BinId, transferredCapacity, currentDateTime);

                }
            }
            catch (Exception ex)
            {
                throw ErrorHandler.Handle(ex, this);
            }

        }

        private void AddWasteTransferLog(int truckId, int binId, double transferredCapacity, DateTime currentDateTime)
        {
            try
            {
                WasteTransferLog wasteTransferLog = new WasteTransferLog()
                {
                    TruckId = truckId,
                    BinId = binId,
                    TransferedCapacity = transferredCapacity,
                    CreatedDate = currentDateTime
                };

                this.db.WasteTransferLogs.Add(wasteTransferLog);

                this.db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ErrorHandler.Handle(ex, this);
            }
        }
    }
}
