using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implemantation;

public class Card : IServices.ICard
{
    Repositories.Interfaces.ICard RepoCard = new Repositories.Implementation.Card();
    MapperConfig myMapper = MapperConfig.Instance;

    public int AddNewCard(DTO.Models.Card card)
    {
        try
        {
            // Check if the user exist
            User user = new User();
            if(! user.IsUserExist(card.UserId))
            {
                return -3;
            }
           
            IMapper mapper = myMapper.CardMapper.CreateMapper();
            Repositories.Models.Card a = mapper.Map<Repositories.Models.Card>(card);
            return RepoCard.AddNewCard(a);
        }
        catch (Exception ex)
        {
            // Handle exceptions if needed
            Console.WriteLine($"Error checking account existence: {ex.Message}");
            return -1; 
        }
    }



    public bool IsCardExistByUserId(int UserId)
    {
        try
        {
            return RepoCard.CheckIfUserHasCard(UserId);
        }
        catch (Exception ex)
        {
            // Handle exceptions if needed
            Console.WriteLine($"Error checking account existence: {ex.Message}");
            return false; // or throw an exception based on your error handling strategy
        }
    }

    public List<DTO.Models.Card> GetAllCards(int id)
    {
        try
        {
           List<Repositories.Models.Card> allUserCards =  RepoCard.GetAllUserCards(id);
            IMapper mapper = myMapper.CardMapper.CreateMapper();
            List<DTO.Models.Card> allCards = allUserCards.Select(card=> mapper.Map<DTO.Models.Card>(card)).ToList();
            return allCards;

        }
        catch
        {
            return new List<DTO.Models.Card>();
        }
    }

    public List<DTO.Models.Card> GetAllCards()
    {
        try
        {
            List<Repositories.Models.Card> allCards = RepoCard.GetAllCards();
            IMapper mapper = myMapper.CardMapper.CreateMapper();
            List<DTO.Models.Card> AllCards = allCards.Select(card => mapper.Map<DTO.Models.Card>(card)).ToList();
            return AllCards;

        }
        catch
        {
            return new List<DTO.Models.Card>();
        }
    }

    public void EncryptDataBase()
    {
        try
        {
            RepoCard.EncryptDataBase();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
