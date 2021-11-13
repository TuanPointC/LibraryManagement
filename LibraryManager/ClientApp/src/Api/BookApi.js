import axios from "axios"
const URL = 'https://localhost:44340/api/book'

export const GetBooks = () => {
    const data= axios.get(URL,{headers:{
        'Authorization':'Bearer '+ localStorage.getItem('token')
    }})
        .then((res) => res.data)
    return data
}

export const PostBook = async (book) => {
    const result = await axios.post(URL,book,{headers:{
        'Authorization':'Bearer '+ localStorage.getItem('token')
    }})
    .then((res)=>res)
    return result
}

export const GetBookById =async (id)=>{
    const result = await axios.get(URL+'/'+id,{headers:{
        'Authorization':'Bearer '+ localStorage.getItem('token')
    }})
        .then ((res)=>res.data)
    return result
}

export const PutBook =async (book)=>{
    const result = await axios.put(URL,book,{headers:{
        'Authorization':'Bearer '+ localStorage.getItem('token')
    }})
        .then ((res)=>res)
    return result
}

export const DeleteBookById = async (id)=>{
    const result = await axios.delete(URL+'/'+id,{headers:{
        'Authorization':'Bearer '+ localStorage.getItem('token')
    }})
        .then ((res)=>res)
    return result
}