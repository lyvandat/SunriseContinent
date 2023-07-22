﻿namespace SunriseServer.Services.HotelService
{
    public interface IPaymentService
    {
        Task<List<Hotel>> GetAllHotels();
        Task<Hotel> GetSingleHotel(int id);
        Task<Hotel> AddHotel(Hotel hotel);
        Task<Hotel> UpdateHotel(int id, Hotel request);
        Task<Hotel> DeleteHotel(int id);

        //
        Task<List<HotelRoomService>> GetHotelServices(int id);
        Task<List<HotelRoomFacility>> GetHotelFacility(int id);
        Task<List<RoomPicture>> GetHotelPicture(int id);
    }
};

