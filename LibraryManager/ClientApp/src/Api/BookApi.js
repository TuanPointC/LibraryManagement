import axios from "axios"
const URL = 'https://localhost:44340/api/book'

export const GetBooks = () => {
    const data= axios.get(URL)
        .then((res) => res.data)
    return data
}

export const PostBook = async (book) => {
    const result = await axios.post(URL,book)
    .then((res)=>res)
    return result
}

export const GetBookById =async (id)=>{
    const result = await axios.get(URL+'/'+id)
        .then ((res)=>res.data)
    return result
}

export const PutBook =async (book)=>{
    const result = await axios.put(URL,book)
        .then ((res)=>res)
    return result
}

export const DeleteBookById = async (id)=>{
    const result = await axios.delete(URL+'/'+id)
        .then ((res)=>res)
    return result
}