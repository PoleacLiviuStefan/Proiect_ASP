import React from 'react'
import { activeId, entry,openModal } from "./Lib";
const Appointment = ({item,stateListener}) => {

    const handlingDelete = (id) =>{
        activeId.id = id
    }
    const handlingEdit= (row)=>{
        Object.assign(entry, row)
        // update state 
        stateListener(Math.random() * 548 * Math.random())
        //open edit modal
        openModal("edit-modal")
    }



    const levelOfImportance = ["Very Low", "Low", "Normal", "Medium", "High", "Very High"];

  return (
    <div className="grid grid-cols-9 ">
    <div className='flex flex-col items-start '>{item.Iid}</div>
    <div className='flex flex-col '>{item.title}</div>
    <div className='flex flex-col'>{item.description}</div>
    <div className='flex flex-col'>{item.levelOfImportance}</div>
    <div className='flex flex-col '>{item.date}</div>
    <div className='flex flex-col '>{item.time}</div>
    <div className='flex flex-col '>{item.address}</div>
    <div className='flex flex-col items-start '>
    <button className='cursor-pointer items-start '>Edit</button>
    </div>
    <div className='flex flex-col items-start '>
    <button className='cursor-pointer text-red-500 '>Delete</button>
    </div>

    </div>
  )
}

export default Appointment