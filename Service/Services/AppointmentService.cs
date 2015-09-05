using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Messages.Requests;
using Repository.Abstract;
using Domain.Entities;
using Service.Messages.Responses;

namespace Service.Services
{
    public class AppointmentService : IAppointmentService
    {
        private IAppointmentRepository repository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            repository = appointmentRepository;
        }

        public AppointmentResponse CreateAppointment(CreateAppointmentRequest appointmentRequest)
        {
            // Create a response object
            AppointmentResponse response = new AppointmentResponse();

            try
            {
                response.Appointment = repository.Create(appointmentRequest.Appointment);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            // Return the response object
            return response;
        }

        public AppointmentResponse GetAppointment(AppointmentRequest appointmentRequest)
        {
            // Create a response object
            AppointmentResponse response = new AppointmentResponse();

            try
            {
                Appointment appointment = repository.GetByID(appointmentRequest.AppointmentID);

                response.Appointment = appointment;
                response.Success = true;
                response.Message = appointment.ID + " was found";
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            // Return the response object
            return response;
        }
    }
}
