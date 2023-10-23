using XtraWork.Entities;
using XtraWork.Repositories;
using XtraWork.Requests;
using XtraWork.Responses;

namespace XtraWork.Services;

public class TitleService
{
    private readonly TitleRepository _titleRepository;

    private readonly ILogger<TitleService> _logger; 

    public TitleService(TitleRepository titleRepository, ILogger<TitleService> logger)
    {
        _titleRepository = titleRepository;
        _logger = logger;
    }

    public async Task<TitleResponse> Get(int id)
    {
        var title = await _titleRepository.Get(id);
        var response = new TitleResponse
        {
            Id = title.Id,
            Description = title.Description
        };
        
        return response;
    }

    public async Task<List<TitleResponse>> GetAll()
    {
        var titles = await _titleRepository.GetAll();
        var response = titles.Select(title => new TitleResponse
        {
            Id = title.Id,
            Description = title.Description
        }).ToList();

        return response;
    }

    public async Task<TitleResponse> Create(TitleRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Description))
        {
            _logger.LogError("Create title Description cannot be empty!");
            throw new BadHttpRequestException(" Description cannot be empty!");
        }
        
        var title = new Title
        {
            Description = request.Description
        };

        await _titleRepository.Create(title);

        return new TitleResponse
        {
            Id = title.Id,
            Description = title.Description
        };
    }

    public async Task<TitleResponse> Update(int id, TitleRequest request)
    {
        var title = await _titleRepository.Get(id);
        title.Description = request.Description;

        await _titleRepository.Update(title);

        return new TitleResponse
        {
            Id = title.Id,
            Description = title.Description
        };
    }

    public async Task Delete(int id)
    {
        await _titleRepository.Delete(id);
    }
}