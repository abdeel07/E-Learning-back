using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_learning_Back.Models;

namespace E_learning_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ElearningContext _context;

        public CommentsController(ElearningContext context)
        {
            _context = context;
        }

        // GET: api/Comments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> GetComments()
        {
            return await _context.Comments.ToListAsync();
        }

        [HttpGet("byCours/{id}")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetByCours(int id)
        {
            var count = await _context.Comments.Where(c => c.IdCours.Equals(id)).ToListAsync();

            return Ok(count);
        }

        [HttpGet("total/")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetTotalComments()
        {
            var count = await _context.Comments.CountAsync();

            return Ok(count);
        }
        //[HttpPost]
        //public async Task<ActionResult<Comment>> PostAvi(Comment avi)
        //{
        //    //Load sample data
        //    var sampleData = new MLModel.ModelInput()
        //    {
        //        Review = avi.Content
        //    };

        //    //Load model and predict output
        //    var result = MLModel.Predict(sampleData);

        //    if (result.PredictedLabel.ToString() == "0")
        //    {
        //        avi.Score = 0;
        //    }
        //    else { avi.Score = 1; }
        //    _context.Comments.Add(avi);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetAvi", new { id = avi.Id }, avi);
        //}

        [HttpGet("negative/")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetTotalCommentsneg()
        {
            var count = await _context.Comments.Where(c => c.Score < 1).CountAsync();

            return Ok(count);
        }

        [HttpGet("negative/{id}")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetCoursNeg(int id)
        {
            var count = await _context.Comments.Where(c => c.Score < 1 && c.IdCours.Equals(id)).CountAsync();

            return Ok(count);
        }

        [HttpGet("possitive/")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetTotalCommentspos()

        {
            var count = await _context.Comments.Where(c => c.Score == 1).CountAsync();

            return Ok(count);
        }

        [HttpGet("possitive/{id}")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetCoursPos(int id)

        {
            var count = await _context.Comments.Where(c => c.Score == 1 && c.IdCours.Equals(id)).CountAsync();

            return Ok(count);
        }

        // GET: api/Comments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetComment(int id)
        {
            var comment = await _context.Comments.FindAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            return comment;
        }

        // PUT: api/Comments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComment(int id, Comment comment)
        {
            if (id != comment.Id)
            {
                return BadRequest();
            }

            _context.Entry(comment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Comments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Comment>> PostComment(Comment comment)
        {
            //Load sample data
                var sampleData = new MLModel.ModelInput()
                {
                    Review = comment.Content
                };

            //Load model and predict output
            var result = MLModel.Predict(sampleData);

            if (result.PredictedLabel.ToString() == "1")
            {
                comment.Score = 1;
            }
            else 
            { 
                comment.Score = 0;
            }

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComment", new { id = comment.Id }, comment);
        }

        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommentExists(int id)
        {
            return _context.Comments.Any(e => e.Id == id);
        }
    }
}
