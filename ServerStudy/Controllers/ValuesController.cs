using Microsoft.AspNetCore.Mvc;

namespace ServerStudy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        [HttpGet]
        public ContentResult Get()
        {
            ////DB에 접근
            ////DB에서 값 가져오기
            ////DB 값 변수에 넣기
            ////변수를 반환하기

            //List<string> msg = new List<string>();
            //msg.Add("Test1");
            //msg.Add("Test2");
            //msg.Add("Test3");

            //return msg;

            //---

            string msg = "<span style='color:red;'> Test1 </span>";

            return Content(msg, "text/html");
            
            //---

        }
    }
}

// 1. API (Application Programming Interface)
// 개념: 서로 다른 소프트웨어가 정해진 방식으로 기능이나 데이터에 접근하고 상호작용할 수 있도록 제공하는 인터페이스
// 비유: 식당의 메뉴판과 주문 규칙 손님(클라이언트)은 주방(서버)에 직접 들어가는 대신, 정해진 메뉴와 주문 방식에 따라 음식을 요청함

// 2. Endpoint
// 개념: 클라이언트가 특정 기능이나 리소스에 접근하기 위해 요청을 보내는 구체적인 주소(URL)
// 비유: 메뉴판에서 주문할 수 있는 개별 메뉴

// 3. Route / Routing
// Route: 특정 요청을 처리할 코드에 연결하도록 정의한 규칙
// Routing: 들어온 요청을 확인하고 적절한 처리 코드로 연결하는 과정
// 비유: 주문을 확인하고 담당 주방에 전달하는 홀 매니저

// 4. Controller
// 개념: 전달받은 요청을 처리하고 응답을 반환하는 역할을 담당하는 코드 필요한 경우 Service 등을 호출하여 실제 작업을 위임함
// 비유: 주문을 받아 주방에 요리를 요청하고, 완성된 음식을 손님에게 전달하는 담당자