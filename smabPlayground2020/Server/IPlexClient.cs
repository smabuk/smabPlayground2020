using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using smabPlayground2020.Shared.PlexInfo.Models;

namespace smabPlayground2020.Server
{
    public interface IPlexClient
    {
        Task<LibraryRoot> GetLibraryRoot() => throw new NotImplementedException();
        Task<LibrarySections> GetLibrarySections() => throw new NotImplementedException();
        Task<LibraryMovies> GetAllMovies() => throw new NotImplementedException();
        Task<LibraryItem?> GetItem(int id) => throw new NotImplementedException();
        Task<LibraryItem?> GetItemChildren(int id) => throw new NotImplementedException();
    }
}
