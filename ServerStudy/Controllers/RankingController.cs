using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerStudy.Data;
using ServerStudy.Models;

namespace ServerStudy.Controllers
{
    //REST 리프리젠테이셔널 스테이트 트랜스퍼
    //HTTP 통신에서 뭔가 일부 기능을 빼서 나름대로 좀 간소화 된 특수한 데이터 송수신 규칙을 만든 것
    //HTTP 통실을 활용해 자원을 CRUD하는 약속된 규칙
    //이 규칙을 잘 따르면 RESTful API라고 부른다

    //[API 응답 반환 규칙]
    //1. null 반환 시: HTTP 204 (No Content) - "데이터 없음"을 요청한 클라이언트에 전달
    //2. string 반환 시: Text/Plain 형식 - 일반 텍스트 그대로 반환
    //3. 기타 객체(List/int/bool 등): Application/Json 형식 - 자동으로 JSON 형식으로 클라이언트에게 전달 

    [Route("api/[controller]")]
    [ApiController]
    public class RankingController : ControllerBase
    {
        ApplicationDbContext _context;

        public RankingController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Read (GET)
        //자원 조회. Body 비워둠. URL 경로(path)나 퀴리 파라미터로 대상(EndPoint) 지정
        //Get => localhost:9999/api/ranking (전체리스트 조회하겠다)
        //Get => localhost:9999/api/ranking/5 (ID가 5인 유저를 조회하겠다)
        [HttpGet]
        public List<GameResult> GetGameResults()  //전체 조회
        {
            List<GameResult> results = _context.GameResults.OrderByDescending(item => item.Score).ToList();

            return results;
        }

        [HttpGet("{id}")]
        public GameResult GetGameResult(int id)  //특정 id만 조회
        {
            GameResult gameResult = _context.GameResults.Where(item => item.Id == id).FirstOrDefault();  //null(default)

            return gameResult;
        }

        //Create (POST)
        //새로운 자원 생성 or 서버에 내가 데이터를 전송할 때. 데이터를 Body 부분에 담아서 전송
        //POST => localhost:9999/api/ranking    |   body : {"userName" : "신소영", "Score" : "999"}
        [HttpPost]
        public bool AddGameResult([FromBody] GameResult gameResult)
        {
            gameResult.Id = 0;

            _context.GameResults.Add(gameResult);
            if (_context.SaveChanges() > 0)
                return true;
            else
                return false;
        }

        //Update (PUT / PATCH) => 보통은 PUT(전체 수정)을 많이 사용, 세밀하게 수정할때는 PATCH(부분 수정) 사용
        //자원 수정. 변경할 데이터를 Body에 담아서 전송
        //PUT => localhost:9999/api/ranking    |   body : {"userName" : "신소영", "Score" : "888"}
        [HttpPut]
        public bool UpdateGameResults([FromBody] GameResult gameResult)
        {
            GameResult findResult = _context.GameResults.Where(item => item.Id == gameResult.Id).FirstOrDefault();
            if (findResult == null)
                return false;

            findResult.UserName = gameResult.UserName;
            findResult.UserEmail = gameResult.UserEmail;
            findResult.Score = gameResult.Score;
            findResult.Date = gameResult.Date;

            _context.SaveChanges();
            return true;
        }

        //Delete (DELETE)
        //자원 삭제. 보통 별도의 Body 없이 URL의 ID만으로 삭제 대상을 지정.
        //DELETE => localhost:9999/api/ranking/5
        [HttpDelete("{id}")]  //verb
        public bool DeleteGameResults(int id)
        {
            GameResult findResult = _context.GameResults.Where(item => item.Id == id).FirstOrDefault();
            if (findResult == null)
                return false;

            _context.GameResults.Remove(findResult);
            _context.SaveChanges();
            return true;
        }
    }
}
