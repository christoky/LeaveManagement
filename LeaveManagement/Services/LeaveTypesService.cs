using AutoMapper;
using LeaveManagement.Data;
using LeaveManagement.Models.LeaveTypes;
using Microsoft.EntityFrameworkCore;
using System.CodeDom;

/*namespace LeaveManagement.Services
{
    public class LeaveTypesService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public LeaveTypesService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
    }
}
*/

//This is the same as above but using the new C# 12.0 feature of primary constructors

/*
namespace LeaveManagement.Services;

public class LeaveTypesService(ApplicationDbContext context, IMapper mapper)
{

}
*/

namespace LeaveManagement.Services;

public class LeaveTypesService(ApplicationDbContext _context, IMapper _mapper) : ILeaveTypesService
{
    public async Task<List<LeaveTypeReadOnlyVM>> GetAll()
    {
        //return View(await _context.LeaveTypes.ToListAsync());
        //samething as above
        //var data = Select * from LeaveTypes
        var data = await _context.LeaveTypes.ToListAsync();

        //convert datamodel into view model
        /*var viewData = data.Select(q => new IndexVM
        {
            Id = q.Id,
            Name = q.Name,
            NumberOfDays = q.NumberOfDays
        });*/

        //Using AutoMapper to convert data model into a view model
        var viewData = _mapper.Map<List<LeaveTypeReadOnlyVM>>(data);

        //Return the data(model) to the view
        return viewData;
    }

    public async Task<T?> Get<T>(int id) where T : class
    {
        //parameterization - key for preventing SQL injection attacks
        //select * from LeaveTypes where Id = id
        var data = await _context.LeaveTypes.FirstOrDefaultAsync(l => l.Id == id);

        if (data == null)
        {
            return null;
        }

        var viewData = _mapper.Map<T>(data);
        return viewData;
    }

    public async Task Remove(int id)
    {
        var data = await _context.LeaveTypes.FirstOrDefaultAsync(l => l.Id == id);

        if (data != null)
        {
            _context.LeaveTypes.Remove(data);
            _context.SaveChanges();
        }
    }

    public async Task Edit(LeaveTypeEditVM model)
    {
        var leaveType = _mapper.Map<LeaveType>(model);
        _context.Update(leaveType);
        await _context.SaveChangesAsync();
    }

    public async Task Create(LeaveTypeCreateVM model)
    {
        //Convert view model to data model
        var leaveType = _mapper.Map<LeaveType>(model); //Hey Mapper, can you map for me the data into LeaveType from LeaveTypeCreate(LeaveTypeCreateVM)
        _context.Add(leaveType);
        await _context.SaveChangesAsync();
    }




    public bool LeaveTypeExists(int id)
    {
        return _context.LeaveTypes.Any(e => e.Id == id);
    }

    public async Task<bool> CheckIfLeaveTypeNameExists(string name)
    {
        var lowerCaseName = name.ToLower();
        return await _context.LeaveTypes.AnyAsync(n => n.Name.ToLower().Equals(lowerCaseName));
    }

    public async Task<bool> CheckIfLeaveTypeNameExistsForEdit(LeaveTypeEditVM leavaTypeEdit)
    {
        var lowerCaseName = leavaTypeEdit.Name.ToLower();
        return await _context.LeaveTypes.AnyAsync(n => n.Name.ToLower().Equals(lowerCaseName) && n.Id != leavaTypeEdit.Id);
    }

}
