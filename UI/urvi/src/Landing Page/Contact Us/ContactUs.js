import React from "react"

function ContactUs() {
    return (
        <div class="container">
            <form>
                <div class="form-group">
                    <label for="name">Name</label>
                    <input type="text" class="form-control" id="name" placeholder="John Doe" />
                </div>
                <div class="form-group">
                    <label for="email">Email Address</label>
                    <input type="email" class="form-control" id="email" placeholder="name@example.com" />
                </div>
                <div class="form-group">
                    <label for="phone">Phone Number</label>
                    <input type="email" class="form-control" id="phone" placeholder="04 xx xxx xxx" />
                </div>
                <div class="form-group">
                    <label for="message">Email address</label>
                    <textarea type="email" class="form-control" id="message" placeholder="Your thoughts!" />
                </div>
                <button type="submit" class="btn btn-primary">Submit</button>
            </form>
        </div>
    )
}

export default ContactUs