﻿using Microsoft.Identity.Client;
using SunriseServerCore.Dtos.Booking;
using SunriseServerCore.Models;
using SunriseServerCore.RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunriseServerData.Repositories
{
    public class BookingRepo : RepositoryBase<BookingAccount>, IBookingRepo
    {
        readonly DataContext _dataContext;

        public BookingRepo(DataContext dataContext) : base (dataContext) {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<BookingAccount>> GetAllAsync(int accountId)
        {
            var result = await _dataContext.Booking_Account.FromSqlInterpolated($"USP_ViewBookingHistory @AccountId = {accountId}").ToListAsync();
            return result;
        }

        public override async Task<BookingAccount> CreateAsync(BookingAccount booking)
        {
            var builder = new StringBuilder("EXECUTE dbo.USP_AddBooking ");
            builder.Append($"@AccountId = \'{booking.AccountId}\', ");
            builder.Append($"@HotelId = \'{booking.HotelId}\', ");
            builder.Append($"@RoomTypeId = \'{booking.RoomTypeId}\', ");
            builder.Append($"@CheckIn = \'{booking.CheckIn}\', ");
            builder.Append($"@CheckOut = \'{booking.CheckOut}\', ");
            builder.Append($"@NumberOfRoom = \'{booking.NumberOfRoom}\', ");
            builder.Append($"@Result = \'{0}\';");

            Console.WriteLine(builder.ToString());
            var result = await _dataContext.Database.ExecuteSqlInterpolatedAsync($"EXECUTE sp_executesql {builder.ToString()}");
            if (result == 0) return null;
            return booking;
        }

        public new async Task<int> UpdateAsync(BookingAccount booking)
        {
            var builder = new StringBuilder("EXECUTE dbo.USP_UpdateBooking ");
            builder.Append($"@AccountId = \'{booking.AccountId}\', ");
            builder.Append($"@HotelId = \'{booking.HotelId}\', ");
            builder.Append($"@RoomTypeId = \'{booking.RoomTypeId}\', ");
            builder.Append($"@CheckIn = \'{booking.CheckIn}\', ");
            builder.Append($"@CheckOut = \'{booking.CheckOut}\', ");
            builder.Append($"@NumberOfRoom = \'{booking.NumberOfRoom}\', ");
            builder.Append($"@Result = \'{0}\';");

            Console.WriteLine(builder.ToString());
            return await _dataContext.Database.ExecuteSqlInterpolatedAsync($"EXECUTE sp_executesql {builder.ToString()}");
        }

        public async Task<int> DeleteAsync(DeleteBookingDto deleteBooking)
        {
            var builder = new StringBuilder("EXECUTE dbo.USP_DeleteBooking ");
            builder.Append($"@AccountId = \'{deleteBooking.AccountId}\', ");
            builder.Append($"@HotelId = \'{deleteBooking.HotelId}\', ");
            builder.Append($"@RoomTypeId = \'{deleteBooking.RoomTypeId}\';");

            Console.WriteLine(builder.ToString());
            return await _dataContext.Database.ExecuteSqlInterpolatedAsync($"EXECUTE sp_executesql {builder.ToString()}");
        }
    }
}
