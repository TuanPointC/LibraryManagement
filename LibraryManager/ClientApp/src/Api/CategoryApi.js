import axios from "axios"
const URL = 'https://localhost:44340/api/category'

export const GetCategories = () => {
    const data= axios.get(URL)
        .then((res) => res.data)
    return data
}

export const PostCategory = async (book) => {
    const result = await axios.post(URL,book)
    .then((res)=>res)
    return result
}

export const GetCategoryById =async (id)=>{
    const result = await axios.get(URL+'/'+id)
        .then ((res)=>res.data)
    return result
}

export const PutCategory =async (book)=>{
    const result = await axios.put(URL,book)
        .then ((res)=>res)
    return result
}

export const DeleteCategoryById =async (id)=>{
    const result = await axios.delete(URL+'/'+id)
        .then ((res)=>res)
    return result
}