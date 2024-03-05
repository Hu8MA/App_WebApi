using Com.Core.Entities;
using Com.Core.EntitiesException;
using Com.Services.File;
using Com.Services.Query;
using Com.ViewModel; 
using Microsoft.AspNetCore.Mvc;
 


namespace Com.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IRepo_UserInfo _UserInfo;
        private readonly IRepo_UserImage _UserImage;
        private readonly IRepo_UserState _UserState;
        private readonly IService_Image _image;
        private readonly IServices_FilePDF _FilePDF;
       

        public AdminController(
            IRepo_UserInfo UserInfo,
            IRepo_UserImage UserImage,
            IRepo_UserState UserState,
            IService_Image image,
            IServices_FilePDF FilePDF


            )
        {
            _UserInfo = UserInfo;
            _UserImage = UserImage;
            _UserState = UserState;
            _image = image;
            _FilePDF = FilePDF;
             
        }

        [HttpGet("Room1")]
        public async Task<ActionResult<IEnumerable<Admin_ViewModel>>> Room1()
        {
            try
            {
                var users = await _UserInfo.ListWithDetails();
                List<Admin_ViewModel> user_Views = new List<Admin_ViewModel>();

                if (users == null || !users.Any())
                {
                    throw new NotFoundException("There are no users yet.");
                }

                foreach (var user in users)
                {
                    if(user is {Is_visible:true , UserState.Room_1:false })
                    {
                        Admin_ViewModel x = new Admin_ViewModel()
                        {
                            IdUser = user.Id,
                            name = user.Name,
                            Location = user.Location,
                            Phone = user.Phonenumber,
                            Timeofpublish = user.TimeOfPublish,
                            state = false
                            
                        };
                        user_Views.Add(x);
                    }
                }

                return Ok(user_Views);
            }
            catch 
            { 
                throw;  
            }
        }

        [HttpGet("Room2")]
        public async Task<ActionResult<IEnumerable<Admin_ViewModel>>> Room2()
        {
            try
            {
                var users = await _UserInfo.ListWithDetails();
                List<Admin_ViewModel> user_Views = new List<Admin_ViewModel>();

                if (users == null || !users.Any())
                {
                    throw new NotFoundException("There are no users yet.");
                }

                foreach (var user in users)
                {
                    if (user is { Is_visible: true, UserState.Room_1: true , UserState.Room_2:false })

                    {
                        Admin_ViewModel x = new Admin_ViewModel()
                        {
                            IdUser = user.Id,
                            name = user.Name,
                            Location = user.Location,
                            Phone = user.Phonenumber,
                            Timeofpublish = user.TimeOfPublish,
                            state = false
                            
                        };
                        user_Views.Add(x);
                    }
                }

                return Ok(user_Views);
            }
            catch 
            { 
                throw;  
            }
        }

        
        [HttpGet("Room3")]
        public async Task<ActionResult<IEnumerable<Admin_ViewModel>>> Room3()
        {
            try
            {
                var users = await _UserInfo.ListWithDetails();
                List<Admin_ViewModel> user_Views = new List<Admin_ViewModel>();

                if (users == null || !users.Any())
                {
                    throw new NotFoundException("There are no users yet.");
                }

                foreach (var user in users)
                {
                    if(user is {Is_visible:true , UserState.Room_1:true , UserState.Room_2:true,UserState.Room_3:false })
                    {
                        Admin_ViewModel x = new Admin_ViewModel()
                        {
                            IdUser = user.Id,
                            name = user.Name,
                            Location = user.Location,
                            Phone = user.Phonenumber,
                            Timeofpublish = user.TimeOfPublish,
                            state = false
                            
                        };
                        user_Views.Add(x);
                    }
                }

                return Ok(user_Views);
            }
            catch 
            { 
                throw;  
            }
        }

        [HttpGet("Room4")]
        public async Task<ActionResult<IEnumerable<Admin_ViewModel>>> Room4()
        {
            try
            {
                var users = await _UserInfo.ListWithDetails();
                List<Admin_ViewModel> user_Views = new List<Admin_ViewModel>();

                if (users == null || !users.Any())
                {
                    throw new NotFoundException("There are no users yet.");
                }

                foreach (var user in users)
                {
                    if (user is { Is_visible: true, UserState.Room_1: true, UserState.Room_2: true, UserState.Room_3: true,UserState.Room_4:false })

                    {
                        Admin_ViewModel x = new Admin_ViewModel()
                        {
                            IdUser = user.Id,
                            name = user.Name,
                            Location = user.Location,
                            Phone = user.Phonenumber,
                            Timeofpublish = user.TimeOfPublish,
                            state = false
                            
                        };
                        user_Views.Add(x);
                    }
                }

                return Ok(user_Views);
            }
            catch 
            { 
                throw;  
            }
        }


        [HttpGet("RoomFinal")]
        public async Task<ActionResult<IEnumerable<Admin_ViewModel>>> Room_Final()
        {
            try
            {
                var users = await _UserInfo.ListWithDetails();
                List<Admin_ViewModel> user_Views = new List<Admin_ViewModel>();

                if (users == null || !users.Any())
                {
                    throw new NotFoundException("There are no users yet.");
                }

                foreach (var user in users)
                {
                    if (user is { Is_visible: true, UserState.Room_1: true, UserState.Room_2: true, UserState.Room_3: true, UserState.Room_4: true,UserState.Room_Final:false })

                    {
                        Admin_ViewModel x = new Admin_ViewModel()
                        {
                            IdUser = user.Id,
                            name = user.Name,
                            Location = user.Location,
                            Phone = user.Phonenumber,
                            Timeofpublish = user.TimeOfPublish,
                            state = false

                        };
                        user_Views.Add(x);
                    }
                }

                return Ok(user_Views);
            }
            catch
            {
                throw;
            }
        }


        [HttpGet("AcceptUser")]
        public async Task<ActionResult<IEnumerable<Admin_ViewModel>>> Accept()
        {
            try
            {
                var users = await _UserInfo.ListWithDetails();
                List<Admin_ViewModel> user_Views = new List<Admin_ViewModel>();

                if (users == null || !users.Any())
                {
                    throw new NotFoundException("There are no users yet.");
                }

                foreach (var user in users)
                {
                    if (user is { Is_visible: true, UserState.Room_1: true, UserState.Room_2: true, UserState.Room_3: true, UserState.Room_4: true, UserState.Room_Final: true,UserState.FinalState:false })

                    {
                        Admin_ViewModel x = new Admin_ViewModel()
                        {
                            IdUser = user.Id,
                            name = user.Name,
                            Location = user.Location,
                            Phone = user.Phonenumber,
                            Timeofpublish = user.TimeOfPublish,
                            state = false

                        };
                        user_Views.Add(x);
                    }
                }

                return Ok(user_Views);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet("AcceptedUsers")]
        public async Task<ActionResult<IEnumerable<Admin_ViewModel>>> Accepted()
        {
            try
            {
                var users = await _UserInfo.ListWithDetails();
                List<Admin_ViewModel> user_Views = new List<Admin_ViewModel>();

                if (users == null || !users.Any())
                {
                    throw new NotFoundException("There are no users yet.");
                }

                foreach (var user in users)
                {
                    if (user is { Is_visible: true, UserState.Room_1: true, UserState.Room_2: true, UserState.Room_3: true, UserState.Room_4: true, UserState.Room_Final: true,UserState.FinalState:true })

                    {
                        Admin_ViewModel x = new Admin_ViewModel()
                        {
                            IdUser = user.Id,
                            name = user.Name,
                            Location = user.Location,
                            Phone = user.Phonenumber,
                            Timeofpublish = user.TimeOfPublish,
                            state = true

                        };
                        user_Views.Add(x);
                    }
                }

                return Ok(user_Views);
            }
            catch
            {
                throw;
            }
        }


        [HttpGet("GetUser")]
        public async Task<ActionResult<AdminState_ViewModel>> GetUser(int IdUser)
        {
            try
            {
                var user = await _UserInfo.Get(IdUser);
                if(user == null)
                {
                    throw new NotFoundException("There are no users yet.");
                }
                
                var images =await _UserImage.GetImagesbyId(user.Id);

                if (images == null )
                {
                    throw new NotFoundException("There are no image's user yet.");

                }

                string hostUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";

                var listUrl = await _image.GetImagesURL(hostUrl, images.Imagepath,user.Id);


                AdminState_ViewModel userstate = new AdminState_ViewModel()
                {
                    IdUser = user.Id,
                    Location = user.Location,
                    name = user.Name,
                    Phone = user.Phonenumber,
                    ImagesUrl = listUrl,
                    Timeofpublish=user.TimeOfPublish,
                };
                 
                return Ok(userstate);
  
            }
            catch
            {
                throw;
            }
        }


        [HttpPost("ChangeStateUser")]
        public async Task<ActionResult> ChangeState([FromBody] AdminChangeState_ViewModel model)
        {
            try
            {
                var user = await _UserInfo.Get(model.userId);
                if (user == null)
                {
                    throw new NotFoundException("There are no users yet.");
                }


                var stateuser = await _UserState.Get(user.Id);

                switch(model.statename)
                {
                   case "Room1":
                        stateuser.Room_1 = model.state;
                    break;

                   case "Room2":
                        stateuser.Room_2 = model.state;
                   break;
                   case "Room3":
                        stateuser.Room_3 = model.state;
                   break;
                   case "Room4":
                        stateuser.Room_4 = model.state;
                   break;
                   case "Room_Final":
                        stateuser.Room_Final = model.state;
                   break;     
                   case "FinalState":
                        stateuser.FinalState = model.state;
                   break;
                   default:
                   throw   new BadRequestException("The Request is Bad ..!");
    
                 

                }

                var result = await _UserState.Update(stateuser);
                return Ok("the user state is upsated");


            }
            catch 
            {

                throw;
            }

        }

        [HttpPost("GetPDF")]
        public async Task<IActionResult> CreatePDF( [FromBody]int userId)
        {
            try
            {
                var user = await _UserInfo.Get(userId);
                if (user == null)
                {
                    throw new NotFoundException("User not found.");
                }

                UserState state = await _UserState.Get(user.Id);
                if (state == null)
                {
                    throw new BadRequestException("the state of user is not found ");
                }
                if(state.FinalState)
                {

                    var htmlcontent =await _FilePDF.GetHTML(user);
                    var pdf = await _FilePDF.CreatePDF(htmlcontent);

                    return File(pdf, "application/pdf", $"{user.Name}.pdf");
                }
                else
                {
                    throw new BadRequestException("this user is not Accepted to now ..!");
                }
                 

            }
            catch 
            {

                throw new BadRequestException("The file cannot be downloaded ..! ");
            }

        }
    
    
    }
}
