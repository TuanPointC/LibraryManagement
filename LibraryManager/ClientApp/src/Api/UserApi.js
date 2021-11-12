import axios from "axios"
const URL = 'https://localhost:44340/api/user'
//const token = localStorage.getItem('token')

export const GetUsers = () => {
    const data= axios.get(URL,{headers:{
        'Authorization':'Bearer '+ localStorage.getItem('token')
    }})
        .then((res) => res.data)
    return data
}

export const PostUser = async (user) => {
    const result = await axios.post(URL,user)
    .then((res)=>res)
    return result
}

export const GetUserById =async (id)=>{
    const result = await axios.get(URL+'/'+id)
        .then ((res)=>res.data)
    return result
}

export const PutUser =async (user)=>{
    const result = await axios.put(URL,user)
        .then ((res)=>res)
    return result
}

export const DeleteUserById =async (id)=>{
    const result = await axios.delete(URL+'/'+id)
        .then ((res)=>res)
    return result
}
