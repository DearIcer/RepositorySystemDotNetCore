using CommonLib;
using IBLL;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Models.Enums;
using RepositorySystemDotNetCore.Filters;

namespace RepositorySystemInterface.Controllers
{
    [Area("Admin")]
    [CustomAttribute]
    public class WorkFlow_InstanceStepController : Controller
    {
        // GET: WorkFlow_InstanceStep
        private IWorkFlow_InstanceStepBLL _workFlow_InstanceStepBLL;
        public WorkFlow_InstanceStepController(IWorkFlow_InstanceStepBLL workFlow_InstanceStepBLL)
        {
            _workFlow_InstanceStepBLL = workFlow_InstanceStepBLL;
        }

        public IActionResult ListView()
        {
            return View();
        }
        public IActionResult UpdateWorkFlow_InstanceStepView()
        {
            return View();
        }

        public IActionResult GetWorkFlow_InstanceStep(int page, int limit)
        {
            int count;
            string userId = HttpContext.Request.Cookies["UserId"];
            List<WorkFlow_InstanceStepDTO> list = _workFlow_InstanceStepBLL.GetWorkFlow_InstanceStep(page, limit, userId, out count);

            ReturnResult result = new ReturnResult()
            {
                Code = 0,
                Msg = "获取成功",
                Data = list,
                IsSuccess = true,
                Count = count
            };

            return Json(result);
        }

        [HttpPost]
        public IActionResult UpdateWorkFlow_InstanceStatus(string id, int outNum, string reviewReason, WorkFlow_InstanceStepStatusEnum reviewStatus)
        {
            var result = new ReturnResult();
            string userId = HttpContext.Request.Cookies["UserId"];
            if (userId == null)
            {
                result.Msg = "登录状态过期";
                return Json(result);
            }
            if (string.IsNullOrWhiteSpace(id))
            {
                result.Msg = "id为空";
                return Json(result);
            }
            if (string.IsNullOrWhiteSpace(reviewReason))
            {
                result.Msg = "审核意见不能为空";
                return Json(result);
            }
            if (outNum < 0)
            {
                result.Msg = "申请数量不能小于零或者对于零";
                return Json(result);
            }
            if (reviewStatus != WorkFlow_InstanceStepStatusEnum.同意 && reviewStatus != WorkFlow_InstanceStepStatusEnum.驳回)
            {
                result.Msg = "审核状态错误";
                return Json(result);
            }

            string msg;
            result.IsSuccess = _workFlow_InstanceStepBLL.UpdateWorkFlow_InstanceStep(id, outNum, reviewReason, userId, reviewStatus, out msg);
            result.Msg = msg;
            result.Code = result.IsSuccess ? 200 : result.Code;

            return Json(result);
        }
    }
}