import React from 'react'
import { IoSettingsSharp } from "react-icons/io5";
import { FaHistory } from "react-icons/fa";
import { ProfileDisplayPageContainer } from './TextElements'

function ProfileDisplayPage() {
  return (
    <>
    <ProfileDisplayPageContainer>

        <div className="card bg-success" style={{borderRadius: "15px"}}>
          <div className="card-body text-center">
            <div className="mt-3 mb-4">
              <img src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-chat/ava2-bg.webp"
                className="rounded-circle img-fluid" style={{width: "100px"}} alt='profile placeholder' />
            </div>
            <h4 className="mb-2">Julie L. Arsenault</h4>
            <p className="text-muted mb-4">@Programmer <span className="mx-2">|</span> <a
                href="#!">mdbootstrap.com</a></p>
            <div className="mb-4 pb-2">
              <button type="button" className="btn btn-outline-dark btn-floating">
              <IoSettingsSharp />
              </button>
              
              <button type="button" className="btn btn-outline-dark btn-floating">
                <FaHistory/>    
              </button>
            </div>
            <button type="button" className="btn btn-dark btn-rounded btn-lg">
              Log out
            </button>
            <div className="d-flex justify-content-between text-center mt-5 mb-2">
              <div>
                <p className="mb-2 h5">8471</p>
                <p className="text-muted mb-0">Wallets Balance</p>
              </div>
              <div className="px-3">
                <p className="mb-2 h5">8512</p>
                <p className="text-muted mb-0">Income amounts</p>
              </div>
              <div>
                <p className="mb-2 h5">4751</p>
                <p className="text-muted mb-0">Total Transactions</p>
              </div>
            </div>

      </div>
    </div>
    </ProfileDisplayPageContainer>
    </>
  )
}

export default ProfileDisplayPage