using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;

namespace TeduShop.Service
{
    public interface IPostCategoryService
    {
        void Add(PostCategory postCategory);

        void Update(PostCategory postCategory);

        void Delete(int id);

        void Delete(PostCategory postCategory);

        IEnumerable<PostCategory> GetAll();

        IEnumerable<PostCategory> GetAllByParrentID(int parentID);

    }
    public class PostCategoryService : IPostCategoryService
    {
        IPostCategoryRepository _posCategoryRepository;
        IUnitOfWork _unitOfWork;

        public PostCategoryService(IPostCategoryRepository postCategoryRepository, IUnitOfWork unitOfWork)
        {
            this._posCategoryRepository = postCategoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(PostCategory postCategory)
        {
            _posCategoryRepository.Add(postCategory);
        }

        public void Delete(PostCategory postCategory)
        {
            _posCategoryRepository.Delete(postCategory);
        }

        public void Delete(int id)
        {
            _posCategoryRepository.Delete(id);
        }

        public IEnumerable<PostCategory> GetAll()
        {
           return _posCategoryRepository.GetAll();
        }

        public IEnumerable<PostCategory> GetAllByParrentID(int parentID)
        {
            return _posCategoryRepository.GetMulti(x => x.Status && x.ParentID == parentID);
        }

        public void Update(PostCategory postCategory)
        {
            _posCategoryRepository.Update(postCategory);

        }
    }
}
