using Magazine.Application.DTOs;

namespace Magazine.Application.Abstractions;


public interface IArticlesService
{
    Task<IEnumerable<ArticleDTO>> GetArticlesByIssueId(int issueId);
}
