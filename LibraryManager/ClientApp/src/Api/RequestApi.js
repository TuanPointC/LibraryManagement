import axios from "axios"
const URL = `${window.location.origin}/api/borrowing_request`

export const GetRequest = () => {
    const data= axios.get(URL,{headers:{
        'Authorization':'Bearer '+ localStorage.getItem('token')
    }})
        .then((res) => res.data)
    return data
}

export const PostRequest = async (request) => {
   const data  = axios.post(URL,request,{headers:{
        'Authorization':'Bearer '+ localStorage.getItem('token')
    }})
    .then((res)=>res)
    .catch((err)=>err.response.data)
    return data
}


export const GetRequestUserId =async (id)=>{
    const result = await axios.get(URL+'/'+id,{headers:{
        'Authorization':'Bearer '+ localStorage.getItem('token')
    }})
        .then ((res)=>res.data)
    return result
}

export const PutRequest =async (request)=>{
    const result = await axios.put(URL,request,{headers:{
        'Authorization':'Bearer '+ localStorage.getItem('token')
    }})
        .then ((res)=>res)
        .catch((err)=>err.response.data)
    return result
}

export const DeleteRequestById =async (id)=>{
    const result = await axios.delete(URL+'/'+id,{headers:{
        'Authorization':'Bearer '+ localStorage.getItem('token')
    }})
        .then ((res)=>res)
        .catch((err)=>err.response.data)
    return result
}
