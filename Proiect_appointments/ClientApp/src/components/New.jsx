import React, { useState } from "react";
import {closeModal,entry, formatedDateToStr, formatedTimeToStr, postAppointment} from './Lib'
const New = ({refreshApp}) => {

    const [titleLength, setTitleLength] = useState(0);
    const [desLength, setDesLength] = useState(0);
    const [addrLength, setAddrLength] = useState(0);


    const newApp = (e)=>{
        const name_=e.target.name
        const v_ = e.target.value


        if(name_ === "title"){
            setTitleLength(v_.length)
        }
        if(name_ === "description"){
            setDesLength(v_.length)
        }
        if(name_ === "address"){
            setAddrLength(v_.length)
        }
        if(name_ === "date"){
            v_ = new Date(v_);
        }

        if(name_ === "levelOfImportance"){
            v_ = Number(v_)
        }

        entry[name_] = v_
    }

    const postApp = () => {
        postAppointment(entry).then(r=> {
            console.log(r);
            refreshApp(Math.random() * 125 * Math.random())
        }).catch(e=> console.log("Error happened at posting new app: ", e))

        closeModal("new-modal")
    }

  return (
    <div className="bg-white w-[30rem] p-[2rem] gap-1">
      <h2 className="font-bold  lg:text-[20px]">New Appointment</h2>
      <div className="flex flex-col">
        <label htmlFor="Title_n">Title</label> 
        <input type="text" maxLength={150} name="title" className="px-1 border-[1px] border-black rounded-[8px] w-[25rem]" onChange={newApp} />
        <span  className="mt-1">{titleLength}/150</span>
      </div>

      <div className="mt-2 flex flex-col">
        <label htmlFor="Description_n">Description</label> 
        <textarea type="text" maxLength={300} name="title" className="py-2 px-1 w-[25rem] h-[10rem] border-[1px] border-black rounded-[8px] w-[250px]" />
        <span className="mt-1">{desLength}/300</span>
      </div>
      <div className="flex items-center mt-2 gap-2">
        <div className="flex flex-col">
          <label htmlFor="Address_n">Adress</label>
          <input type="text" id="Address_n" name="address" onChange={newApp} className="border-[1px] border-black rounded-[8px] w-[250px]" maxLength={100} />
          <span className="">{addrLength} / 100</span>
        </div>

        <div className="flex items-center mt-1 gap-2">
          <label htmlFor="LevelOfImportance_n">Importance</label>
          <select
            name="levelOfImportance"
            id="LevelOfImportance_n"
            defaultValue={2}
           
          >
            <option value={5}>Very High</option>
            <option value={4}>High</option>
            <option value={3}>Medium</option>
            <option value={2}>Normal</option>
            <option value={1}>Low</option>
            <option value={0}>Very Low</option>

          </select>
        </div>
      </div>
      <div className="flex mt-4 gap-2">
            <div className="flex gap-2"> 
                <label htmlFor="" >Date</label>
                <input type="date" className="border-[1px] border-black rounded-[5px] px-2" defaultValue={formatedDateToStr()} onChange={newApp} />
            </div>

            <div className="flex gap-2">
                <label htmlFor="Time_n" >Time</label>
                <input type="time"  className="time border-[1px] border-black rounded-[5px] px-2"  onChange={newApp} defaultValue={formatedTimeToStr()}  />
            </div>
      </div>
      <div className="mt-4 flex items-center gap-4">

<div className=" flex gap-2">
  <label>Done</label>
  <input type="radio"/>
  </div>

  <div className="flex gap-2">
  <label>Deleted</label>
  <input type="radio"/>
  </div>
  </div>
      <div className="flex justify-between mt-4 ">
        <button onClick={()=>closeModal("new-modal")} className="bg-red-500 rounded-[5px] text-white px-4 py-2 hover:bg-red-400">Cancel</button>
        <button onClick={postApp} className="bg-green-500 rounded-[5px] text-white px-4 py-2 hover:bg-green-400">Add</button>
      </div>

 
    </div>
  );
};

export default New;
