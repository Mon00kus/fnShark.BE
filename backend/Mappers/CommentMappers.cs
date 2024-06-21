﻿using backend.Dtos.Comment;
using backend.Models;

namespace backend.Mappers
{
    public static class CommentMappers
    {
        public static CommentDto ToCommentDto(this Comment commentModel)
        {
            return new CommentDto
            {
                Id = commentModel.Id,
                Title = commentModel.Title,
                Content = commentModel.Content,
                CreatedOn = commentModel.CreateOn,      
                CreatedBy = commentModel.AppUser.UserName!,
                StockId = commentModel.StockId                
            };
        }
        public static Comment ToCommentFromCreate(this CreateCommentDto commentDto, int stockId)
        {
            return new Comment
            {                
                Title = commentDto.Title,
                Content = commentDto.Content,                                
                StockId = stockId
            };
        }
        public static Comment ToCommentFromUpdate(this UpdateCommentRequestDto commentDto, int stockId)
        {
            return new Comment
            {
                Title = commentDto.Title,
                Content = commentDto.Content,
                StockId = stockId
            };
        }
    }
}
