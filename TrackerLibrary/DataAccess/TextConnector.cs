using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;
using TrackerLibrary.DataAccess.TextHelpers;

namespace TrackerLibrary.DataAccess
{
    public class TextConnector : IDataConnection
    {
        private const string PrizesFile = "PrizeModels.csv";

        public PrizeModel CreatePrize(PrizeModel model)
        {
            // Load the text file and Convert the text file to List<PrizeModel>
            List<PrizeModel> prizes = PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels();   // Extension Methods Chaining

            // Order prizes descending by id and get the first one(the greatest id) + 1 
            // It basically gets the id for adding a new record ( maxId + 1)
            int currentId = 1;
            if(prizes.Count > 1)
            {
                currentId = prizes.OrderByDescending(x => x.Id).First().Id + 1;
            }
            model.Id = currentId;

            // Add the new record with the max id
            prizes.Add(model);

            // Convert the prizes to List<string>
            // Save the List<string> to text file
            prizes.SaveToPrizeFile(PrizesFile);

            return model;
        }
    }
}
