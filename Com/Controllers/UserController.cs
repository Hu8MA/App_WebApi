using Com.Core.Entities;
using Com.Core.EntitiesException;
using Com.Core.ValueObject;
using Com.Services.File;
using Com.Services.Query;
using Com.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Com.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepo_UserInfo _UserInfo;
        private readonly IRepo_UserImage _UserImage;
        private readonly IRepo_UserState _UserState;
        private readonly IService_Image _image;
        private readonly Image_Value _Value;

        public UserController(
            IRepo_UserInfo   UserInfo,
            IRepo_UserImage  UserImage,
            IRepo_UserState  UserState,
            IService_Image  image,
            Image_Value Value
            )
        {
            _UserInfo = UserInfo;
            _UserImage = UserImage; 
            _UserState = UserState;
            _image = image;
            _Value = Value;
        }


        [HttpPost("UploadInfo")]
        public async Task<IActionResult>Upload( User_ViewModel model)
        {
            try
            { 
               if (ModelState.IsValid)
               {
                     
                    foreach (var item in model.Images)
                     {
                        if(! _Value.CheckImageSize(item))
                         {
                            throw new BadRequestException("the One of Images ,have size is Up of 4 MB Or Image extension is not support ...!"); ;
                         }
                    }
 
                  
                    UserInfo user = new UserInfo()
                     {
                            Name = model.Name,
                            Location = model.Location,
                            Phonenumber = model.Phonenumber,
                            TimeOfPublish=DateTime.UtcNow,
                            Is_visible=true
                    };

                  var usersave = await _UserInfo.Add(user);

                    if(!usersave)
                    {
                        throw new BadRequestException("the request have error ...!"); ;
                    }

                    string path = string.Empty;
                    foreach (var item in model.Images)
                    {
                        path = await _image.Save(item, user.Id);
                    }
                    UserImage userImage = new UserImage()
                    {
                        IdUser = user.Id,
                        Is_visible = true,
                        Imagepath = path
                    };

                    var imageresult=await _UserImage.Add(userImage);
                    if(!imageresult)
                    {
                            throw new BadRequestException("the request have error ...!"); ;
                    }
                   

                    UserState state = new UserState();
                    state.IdUser = user.Id;
                    var stateresult=await _UserState.Add(state);

                   if(!stateresult)
                   {
                        throw new BadRequestException("the request have error ...!"); ;
                   }

                 return Ok();
               }

               else
               {
                    throw new BadRequestException("the request have error ...!"); ;
               }
            }

            catch
            {
                throw  ;

            }
        }


        


    }
}
