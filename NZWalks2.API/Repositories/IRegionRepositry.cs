using NZWalks2.API.Models.Domain;

namespace NZWalks2.API.Repositories
{
    public interface IRegionRepositry
    {
        //this interface will contain the definition of the function that we 
        //want to expose 
        //1.GetAll
        //2.GetById
        //3.Create
        //4.Update
        //5.Delete

        #region Get All method
        Task<List<Region>> GetAllRegionsAsync();

        #endregion

        #region Get By Id
        Task<Region?> GetByidAsync(Guid id);


        #endregion

        #region Create
        Task<Region> CreateRegionAsync(Region region);
        #endregion

        #region Update
        Task<Region?> UpdateRegionAsync(Guid id,Region region);
        #endregion

        #region Delete
        Task < Region?> DeleteRegionAsync(Guid id);

        #endregion
    }
}
