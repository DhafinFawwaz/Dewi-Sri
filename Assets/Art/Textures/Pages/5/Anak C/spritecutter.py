# get all image ends with .png or .PNG or .jpg or .JPG or >jpeg or .JPEG
# and cut them from 0,0 to 2048,2048
# and save them to a new folder named "cutted"

import os
from PIL import Image

def cut_image(image_path, left, upper, right, lower):
    img = Image.open(image_path)
    img = img.crop((left, upper, right, lower))
    return img

def main():
    if not os.path.exists("cutted"):
        os.makedirs("cutted")

    for file in os.listdir("."):
        if file.endswith(".png") or file.endswith(".PNG") or file.endswith(".jpg") or file.endswith(".JPG") or file.endswith(".jpeg") or file.endswith(".JPEG"):
            img = cut_image(file, 2446, 609, 2446+2048, 609+2048)
            img.save("cutted/" + file)

if __name__ == "__main__":
    main()