using DDD_CommunitySystem.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDD_CommunitySystem.Domain.Entity;

namespace DDD_CommunitySystem.Infrastructure.Repository
{
    public class FriendshipRepository : IFriendshipRepository
    {

        private IDbContext _context;
        private IUnitOfWork _unitofwork;


        public FriendshipRepository(IDbContext context, IUnitOfWork unitofwork)
        {

            _context = context;
            _unitofwork = unitofwork;
        }

        public void Add(Friendship friendship)
        {
            _context.Friendship.Add(friendship);
        }

        public IEnumerable<Friendship> Get(Guid userId)
        {
            return null;
        }

        public Friendship Get(Guid applicanUsertId, Guid receiverUserId)
        {
            return null;
        }

        public void Update(Friendship friendship)
        {
            throw new NotImplementedException();
        }
    }
}
