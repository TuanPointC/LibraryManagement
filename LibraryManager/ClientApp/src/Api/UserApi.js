import axios from "axios"
const URL = 'https://localhost:44340/api/user'

export const GetUsers = () => {
    const data= axios.get(URL)
        .then((res) => res.data)
    return data
}

export const PostUser = (user) => {
    axios.post(URL,user)
}
