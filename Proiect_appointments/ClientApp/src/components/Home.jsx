import Appointment from "./Appointment";
import Delete from "./Delete";
import Edit from "./Edit";
import New from "./New";
import { useEffect, useState } from "react";
import {getDefault, testData, openModal} from './Lib'

const Home = (props) => {
  const [dataList, setDataList] = useState([]);
  const [refreshData, setRefreshData] = useState(0);
  const [stateListener, setStateListener] = useState(0);

  useEffect(()=>{
      getDefault().then(data=>{
        setDataList(data)
      }).catch(e=>console.log("Error inside home: ", e))

  },[refreshData])

  return (
    <div>
      <h1 className=" font-bold">Manage Your Appointments / Dates very easy</h1>
      <p>
        This powerful web application helps you to manage your dates very easy.
      </p>
      <div className="flex items-center justify-center">
        <button className="cursor-pointer bg-[rgb(16_122_67)] text-[30px] text-white font-bold  shadow-[0_0_2px_2px_rgb(39_153_39)] py-[5px] px-[13px]" onClick={()=> openModal("new-modal")}>
          +
        </button>
      </div>
      <p className="pt-[20px] ">This is a test TEXT</p>
      <section className="flex justify-between items-center ">
        <div className="">Filter</div>
        <div className="flex items-center gap-2 ">
          <button className="border-[1px] border-black">Clear Filters</button>
          <div className="flex flex-col items-center">
            <label htmlFor="All_f">All</label>
            <input type="checkbox" name="All" />
          </div>
          <div className="flex flex-col items-center">
            <label htmlFor="Done_f">Done</label>
            <input type="checkbox" name="Done" />
          </div>
          <div className="flex flex-col items-center ">
            <label htmlFor="Ddeleted_f">Deleted</label>
            <input type="checkbox" name="Deleted" />
          </div>
          <label htmlFor="period">Period</label> <br />
          <select name="period" defaultValue={"4"}>
            <option value="5" disabled>
              Period
            </option>
            <option value="4">Default</option>
            <option value="1">Today</option>
            <option value="2">This week</option>
            <option value="3">Last week</option>
          </select>
          <div className="flex gap-2">
            <label htmlFor="SpecifiedDate">Specified Date</label>
            <input type="date" className="px-2" />
          </div>
          <div className="flex gap-2">
            <label htmlFor="SpecifiedTime">Specified Time</label>
            <input type="date" className="px-2" />
          </div>
          <div>
            <label>Level of Importance</label>
            <select name="LevelOfImportance" defaultValue={8}>
              <option value={8} disabled>
                Level Of Importance
              </option>
              <option value={9}>Reset</option>
              <option value={5}>Very High</option>
              <option value={4}>High</option>
              <option value={3}>Mediu</option>
              <option value={2}>Normal</option>
              <option value={1}>Low</option>
              <option value={0}>Very Low</option>
            </select>
          </div>
        </div>
      </section>
      <div className="my-4 w-full bg-black opacity-[60%] h-[1px] "/>
      <div className="mt-4 grid grid-cols-9 justify-center font-bold">
        <div className="w-[20px]">#</div>
        <div className="w-[17%]">Title</div>
        <div className="w-[35%]">Description</div>
        <div className="w-[10%]">Importance</div>
        <div className="w-[110px]">Date</div>
        <div className="w-[40px]">Time</div>
        <div className="w-[15%]">Adress</div>
        <div className="w-[50px]">Edit</div>
        <div className="w-[50px]">Delete</div>
      </div>

      {dataList.length === 0 ? (
        <div className="flex mt-15">
          Loading <div className="loading">...</div>
        </div>
      ) : (
        dataList?.map((item) => <Appointment item={item} key={item.id} stateListener={setStateListener} />)
      )}
      <section >
        <div className="new-modal absolute top-0 left-0 flex justify-center items-center w-screen h-screen bg-black bg-opacity-50 rounded-[8px] hidden">
        <New refreshApp={setRefreshData}/>
        </div>
        <div className="edit-modal absolute top-0 left-0 flex justify-center items-center w-screen h-screen bg-black bg-opacity-50 rounded-[8px] hidden">
        <Edit stateListener={stateListener}/>
        </div>
        <div className="delete-modal absolute top-0 left-0 flex justify-center items-center w-screen h-screen bg-black bg-opacity-50 rounded-[8px] hidden">
        <Delete stateListener={stateListener}/>
        </div>
      </section>
    </div>
  );
};

export default Home;
