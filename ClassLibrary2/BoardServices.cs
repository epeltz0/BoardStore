using BoardBrowser.Data;
using BoardBrowser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoardBrowser.Services
{
    public class BoardServices
    {
        private readonly Guid _userId;

        public BoardServices(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateBoard(BoardCreate model)
        {
            var entity =
                new Board()
                {
                    BoardName = model.BoardName,
                    Description = model.Description,
                    Price = model.Price,
                    BoardCategory = model.BoardCategory,
                    BoardQuality = model.BoardQuality
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Boards.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<BoardListItem> GetBoards()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Boards
                        .Select(
                        
                            e =>
                                new BoardListItem
                                {
                                    BoardId = e.BoardId,
                                    BoardName = e.BoardName,
                                    BoardCategory = e.BoardCategory,
                                    BoardQuality = e.BoardQuality
                                }
                        );

                return query.ToArray();
            }
        }

        public BoardDetails GetBoardById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Boards
                        .Single(e => e.BoardId == id);
                return
                    new BoardDetails
                    {
                        BoardId = entity.BoardId,
                        BoardName = entity.BoardName,
                        Description = entity.Description,
                        Price = entity.Price,     
                        BoardCategory = entity.BoardCategory,
                        BoardQuality = entity.BoardQuality
                    };
            }
        }

        public bool UpdateBoard(BoardEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Boards
                        .Single(e => e.BoardId == model.BoardId);

                entity.BoardCategory = model.BoardCategory;
                entity.BoardName = model.BoardName;
                entity.Description = model.Description;
                entity.Price = model.Price;
                entity.BoardQuality = model.BoardQuality;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteBoard(int boardId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Boards
                        .Single(e => e.BoardId == boardId);

                ctx.Boards.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }


    }
}
