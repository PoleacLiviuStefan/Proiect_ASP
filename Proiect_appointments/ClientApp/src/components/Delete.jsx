import React from 'react'
import {activeId, closeModal, deleteAppointment} from './Lib'


const Delete = () => {

    const deleteApp = () => {
        deleteAppointment(activeId.id).then(r=> console.log("Deleted successfully: ", r))
        .catch(e=>console.log("Could not delete the appointment: ", e))

        closeModal("delete-modal");
    }

  return (
    <div className='w-[30rem] bg-white p-4'>
        <h3 className='font-bold'> Warning deleting the Appointment</h3>
        <p>Are you sure you want to delete the Appointment?</p>

        <div className='mt-2 flex justify-between'>
            <button className='bg-red-500 px-2 py-1 rounded-[5px] text-white' onClick={()=>closeModal("delete-modal")}>Cancel</button>
            <button className='bg-green-500 px-2 py-1 rounded-[5px] text-white' onClick={deleteApp}>Update</button>
        </div>
    </div>
  )
}

export default Delete