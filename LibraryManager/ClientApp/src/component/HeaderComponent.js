import { Button } from 'antd';
import { useEffect,useState } from 'react';
import { success } from './Message';

const HeaderComponent = () => {
    const [user,setUser] =  useState(undefined)

    useEffect(()=>{
        setUser(localStorage.getItem("userName"))
    },[user])


    const handleClick =async ()=>{
        if(!user){
            window.location.href=window.location.href.split("/user")[0]+'/login'
        }
        else{
            localStorage.removeItem("token")
            localStorage.removeItem("userName")
            localStorage.removeItem("userId")
            localStorage.removeItem("userEmail") 
            await success("logout")
            setUser(undefined)
        }
    }

    return (
        <div style={{ display: 'flex', alignItems: 'center', height: '60px' }}>
            <div style={{ flex: "1", fontWeight: 'bold', fontSize: '25px', textShadow: '6px 6px 0px rgba(0,0,0,0.2)' }}>Library Management</div>
            <div style={{ flex: "1" }}>Wellcome {user}</div>
            <div>
               <Button onClick={handleClick}>{!user?"Login":'Logout'}</Button>
            </div>
        </div>
    )
}

export default HeaderComponent;