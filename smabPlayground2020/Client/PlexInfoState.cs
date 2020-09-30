using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using smab.PlexInfo.Models;

namespace smabPlayground2020.Client
{
    public class PlexInfoState
    {
        public List<MovieSummary>? MoviesList { get; set; }
        public List<TvShowSummary>? TvShowsList { get; set; }

    }
}
