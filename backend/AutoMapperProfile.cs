using AutoMapper;
using Bambus.Models;
using Bambus.DTOs.ItemDtos;
using Bambus.DTOs.UserDtos;
using Bambus.DTOs.LoanDtos;
using Bambus.DTOs.MessageDtos;
using Bambus.DTOs.RatingDtos;

namespace Bambus.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<LoanModel, GetLoanDTO>();
            CreateMap<CreateLoanDTO, LoanModel>();
            CreateMap<MagazineModel, GetItemDTO>();
            CreateMap<BookModel, GetItemDTO>();
            CreateMap<GameModel, GetItemDTO>();
            CreateMap<ItemModel, GetItemDTO>();
            CreateMap<AddItemDTO, ItemModel>();
            CreateMap<UpdateItemDTO, ItemModel>();
            CreateMap<MessageModel, GetMessageDTO>();
            CreateMap<AddMessageDTO, MessageModel>();
            CreateMap<MessageModel, AddMessageDTO>();
            CreateMap<UserModel, GetUserDTO>();
            CreateMap<RegisterDTO, UserModel>();
            CreateMap<RatingModel, GetRatingDTO>();
            CreateMap<AddRatingDTO, RatingModel>();
            CreateMap<UpdateRatingDTO, RatingModel>();
            CreateMap<RatingModel, AddRatingDTO>();
        }
    }
}