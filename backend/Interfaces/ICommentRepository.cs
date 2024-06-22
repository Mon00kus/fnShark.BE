using backend.Helpers;
using backend.Models;

namespace backend.Interfaces
{
    public interface ICommentRepository
    {
        public Task<List<Comment>> GetAllAsync(CommentQueryObject commentQueryObject);
        public Task<Comment?> GetByIdAsync(int id);
        public Task<Comment> CreateAsync(Comment comment);
        public Task<Comment?> UpdateAsync(int id, Comment comment);
        public Task<Comment> DeleteAsync(int id);
    }
}
