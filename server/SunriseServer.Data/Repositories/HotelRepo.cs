﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SunriseServerData;
using SunriseServerCore.Models;
using SunriseServerCore.RepoInterfaces;
using Microsoft.Data.SqlClient;
using SunriseServer.Common.Helper;

namespace SunriseServerData.Repositories
{
    public class HotelRepo : RepositoryBase<Hotel>, IHotelRepo
    {
        readonly DataContext _dataContext;
        public HotelRepo(DataContext dbContext) : base(dbContext) 
        {
            _dataContext = dbContext;
        }

        public override async Task<IEnumerable<Hotel>> GetAllAsync()
        {
            var result = await _dataContext.Hotel.FromSqlInterpolated($"USP_GetAllHotel").ToListAsync();
            return result;
        }

        public override async Task<Hotel> GetByIdAsync(int id)
        {
            var result = await _dataContext.Hotel.FromSqlInterpolated($"USP_GetHotelById @Id = {id}").ToListAsync();
            return result.FirstOrDefault();
        }

        public override async Task<Hotel> CreateAsync(Hotel entity)
        {           
            var builder = new StringBuilder("DECLARE @result INT;\n");
            builder.Append("EXEC @result = dbo.USP_AddHotel ");

            builder.Append($"@Name = \'{entity.Name}\', ");
            builder.Append($"@Country = \'{entity.Country}\', ");
            builder.Append($"@HotelType = \'{entity.HotelType}\', ");
            builder.Append($"@ProvinceCity = \'{entity.ProvinceCity}\', ");
            builder.Append($"@Address = \'{entity.Address}\', ");
            builder.Append($"@Stars = {entity.Stars}, ");
            builder.Append($"@Rating = {entity.Rating}, ");
            builder.Append($"@Description = \'{entity.Description}\', ");
            builder.Append($"@Image = \'{entity.Image}\';\n");
            builder.Append($"EXEC USP_GetHotelById @Id = @result;");

            Console.WriteLine(builder.ToString());

            var result = await _dataContext.Hotel.FromSqlInterpolated($"EXECUTE({builder.ToString()})").ToListAsync();
            return result.FirstOrDefault();
        }

        // Task<TModel> UpdateAsync(TModel entity);

        // TModel Delete(int id);


        // More info
        public async Task<List<RoomFacilityConstant>> GetHotelFacilityAsync(int id)
        {
            var result = await _dataContext.RoomFacilityConstants.FromSqlInterpolated($"exec USP_GetHotelRoomFacility @Id={id};").ToListAsync();
            return result;
        }

        public async Task<List<RoomServiceConstant>> GetHotelServiceAsync(int id)
        {
            var result = await _dataContext.RoomServiceConstants.FromSqlInterpolated($"exec USP_GetHotelRoomService @Id={id};").ToListAsync();
            return result;
        }

        public async Task<List<RoomPicture>> GetHotelPictureAsync(int id)
        {
            var result = await _dataContext.RoomPicture.FromSqlInterpolated($"exec USP_GetHotelRoomPicture @Id={id};").ToListAsync();
            return result;
        }
    }
}
