using backend.Data;
using backend.Interfaces;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.Include(a => a.AppUser).ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _context.Comments.Include(a => a.AppUser).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Comment> CreateAsync(Comment comment)
        {
            try
            {
                comment.CreateOn = comment.CreateOn.ToUniversalTime();
                await _context.Comments.AddAsync(comment);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw(ex.InnerException!);
            }
            
            return comment;
        }


        public async Task<Comment> DeleteAsync(int id)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(x=> x.Id == id);
            if (comment == null)
            {
                return null!;
            }            
            _context.Comments.Remove(comment!);
            await _context.SaveChangesAsync();
            return comment!;
        }
        public async Task<Comment?> UpdateAsync(int id, Comment commentModified)
        {
            var existingComment = await _context.Comments.FindAsync(id);            

            if (existingComment == null)
            {
                return null;
            }           

            existingComment.Title = commentModified.Title;
            existingComment.Content = commentModified.Content;
            
            await _context.SaveChangesAsync();

            return existingComment;
        }
    }
}
