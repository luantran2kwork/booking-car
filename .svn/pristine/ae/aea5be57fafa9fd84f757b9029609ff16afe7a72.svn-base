import React from "react";
import {
  View,
  Text,
  Image,
  TouchableOpacity,
  Dimensions,
  StyleSheet,
  Modal,
  FlatList,
  ActivityIndicator,
} from "react-native";
import adm_Attachment from "../Entities/adm_Attachment";
import ApiUrl from "../constants/ApiUrl";
import FontAwesome5 from "react-native-vector-icons/FontAwesome5";
import ImageViewer from "react-native-image-zoom-viewer";
import * as ImagePicker from "expo-image-picker";
import * as Permissions from "expo-permissions";
import SMX from "../constants/SMX";
import * as Enums from "../constants/Enums";
import AttachmentDto from "../DtoParams/AttachmentDto";
import GlobalStore from "../Stores/GlobalStore";
import { inject, observer } from "mobx-react";
import HttpUtils from "../Utils/HttpUtils";
import { ClientMessage } from "../SharedEntity/SMXException";
import * as ImageManipulator from "expo-image-manipulator";
import PopUpModalABB from "./PopUpModalABB";

const { width, height } = Dimensions.get("window");

interface iProps {
  navigation: any;
  Images: adm_Attachment[];
  numberColumn: number;
  allowEdit?: boolean;
  allowRemove?: boolean;
  IsHasSoDoVeTinh?: boolean;
  IsHasSoDoQuyHoach?: boolean;
  AttachmentSoDoVeTinh?: adm_Attachment;
  AttachmentSoDoQuyHoach?: adm_Attachment;
  GlobalStore?: GlobalStore;
}
interface iState {
  SelectedFullScreen: adm_Attachment;
  SelectedDefault: adm_Attachment;
  showPopUp: boolean;
  LoaddingIndexSelected: number;
  LoaddingIndexShow: number;
  LoaddingImageSDVT: boolean;
  showLoaddingImageSDVT: boolean;
  showLoaddingImageSDQH: boolean;
  SelectedImageInFlatList: boolean;
  uploadType: number; //Loại show upload ảnh
}
@inject(SMX.StoreName.GlobalStore)
@observer
export default class GalleryAsset extends React.Component<iProps, iState> {
  timerId = null;

  constructor(props: iProps) {
    super(props);
    this.state = {
      SelectedFullScreen: null,
      SelectedDefault: null,
      showPopUp: false,
      LoaddingIndexSelected: -1,
      LoaddingIndexShow: -1,
      LoaddingImageSDVT: false,
      showLoaddingImageSDVT: false,
      showLoaddingImageSDQH: false,
      SelectedImageInFlatList: false,
      uploadType: Enums.UploadPopupType.Default, //Mặc định là 0
    };
  }

  async handleEdit(attachment: adm_Attachment) {
    try {
      //@ts-ignore
      //status === "granted";
      let result = await ImagePicker.launchImageLibraryAsync({
        mediaTypes: ImagePicker.MediaTypeOptions.Images,
        base64: true,
        quality: 0.1,
      });
      if (!result.cancelled) {
        this._handleImagePickedEdit(result, attachment);
      }
    } catch (ex) { }
  }

  _handleImagePickedEdit = async (result, attachment: adm_Attachment) => {
    try {
      var att = new adm_Attachment();
      att = attachment;
      att.FileContent = result.base64;

      if (result.uri.toString() != "") {
        let uriArray = result.uri.toString().split("/");

        if (uriArray.length > 0) {
          let filename = uriArray[uriArray.length - 1];

          att.FILE_NAME = filename;
          att.DISPLAY_NAME = filename;
          let fileExternal = filename.split(".")[1];
          att.FILE_CONTENT_TYPE = "image/" + fileExternal;
        }
      }

      // upload ảnh
      ImageManipulator.manipulateAsync(
        result.uri,
        [{ resize: { width: result.width / 2, height: result.height / 2 } }],
        {
          compress: 0.8,
          base64: true,
        }
      )
        .then((result) => {
          att.IMAGE_BASE_64_STRING = result.base64;
          this.saveImage(att);
        })
        .catch((e) => {
          this.saveImage(att);
        });
      this.setState({ SelectedFullScreen: att });
      // let mess = "Tải ảnh thành công!";
      // this.props.GlobalStore.Exception = ClientMessage(mess);
    } catch (ex) {
      this.props.GlobalStore.Exception = ex;
    }
  };

  saveImage(att: adm_Attachment) {
    var req = new AttachmentDto();
    req.Attachment = att;
    HttpUtils.post<AttachmentDto>(
      ApiUrl.Attachment_Execute,
      SMX.ApiActionCode.UploadImage,
      JSON.stringify(req)
    );
  }

  async handleRemove(attachment: adm_Attachment) {
    try {
      if (this.state.SelectedImageInFlatList) {
        this.setState({
          LoaddingIndexShow: this.state.LoaddingIndexSelected,
        });
      }
      var req = new AttachmentDto();
      req.Attachment = attachment;
      await HttpUtils.post<AttachmentDto>(
        ApiUrl.Attachment_Execute,
        SMX.ApiActionCode.DeletedImage,
        JSON.stringify(req)
      );

      this.setState({ SelectedFullScreen: null });
      if (this.state.SelectedImageInFlatList) {
        //Gán trigger khi có có sự kiện xóa ảnh trong flatlist
        this.props.GlobalStore.ImageChangedInFlatList =
          this.state.SelectedImageInFlatList;

        //Tắt loadding ảnh
        this.setState({
          LoaddingIndexShow: -1,
        });
      }
      this.props.GlobalStore.ImageValueUpdatedSDVT = null;

      this.props.GlobalStore.UpdateImageTrigger();
    } catch (ex) {
      this.props.GlobalStore.Exception = ex;
      this.props.GlobalStore.HideLoading();
    }
  }

  checkIsNotImage(img: adm_Attachment) {
    let result = false;
    if (img.FILE_NAME && img.FILE_NAME !== null && img.FILE_NAME !== "") {
      let ext = img.FILE_NAME.split(".");
      if (
        ext &&
        ext.length > 0 &&
        (ext[1] === "pdf" || ext[1] === "xlsx" || ext[1] === "docx")
      ) {
        result = true;
        return result;
      }
    }

    return false;
  }

  //Chụp ảnh và lưu từ ảnh vừa chụp
  _pickImageCamera = async () => {
    //@ts-ignore
    //status === "granted";
    try {
      let { status } = await Permissions.getAsync(
        Permissions.CAMERA,
        Permissions.CAMERA_ROLL
      );

      if (status !== "granted") {
        //@ts-ignore
        let status1 = await (
          await Permissions.askAsync(
            Permissions.CAMERA,
            Permissions.CAMERA_ROLL
          )
        ).status;

        if (status1 !== "granted") {
          return;
        }
      }

      this.timerId = setInterval(() => {
        clearInterval(this.timerId);
        this.setState({ LoaddingIndexShow: this.state.LoaddingIndexSelected });
      }, 1000);

      let result: any = await ImagePicker.launchCameraAsync({
        mediaTypes: ImagePicker.MediaTypeOptions.Images,
        quality: 0.8,
        allowsEditing: false,
        base64: true,
      });

      if (!result.cancelled) {
        await this._handleImagePicked(result);
      } else {
        this.setState({ LoaddingIndexShow: -1 });
      }
    } catch (ex) {
      this.setState({ LoaddingIndexShow: -1 });
      this.props.GlobalStore.Exception = ex;
    }
  };

  //Tải ảnh lên từ thư viện ảnh
  _pickImage = async () => {
    try {
      //@ts-ignore
      //status === "granted";

      this.timerId = setInterval(() => {
        clearInterval(this.timerId);
        this.setState({ LoaddingIndexShow: this.state.LoaddingIndexSelected });
      }, 1000);

      let result = await ImagePicker.launchImageLibraryAsync({
        mediaTypes: ImagePicker.MediaTypeOptions.Images,
        base64: true,
        quality: 0.8,
      });

      if (!result.cancelled) {
        this._handleImagePicked(result);
      } else {
        this.setState({ LoaddingIndexShow: -1 });
      }
    } catch (ex) {
      this.setState({ LoaddingIndexShow: -1 });
      this.props.GlobalStore.Exception = ex;
    }
  };

  _handleImagePicked = async (result) => {
    try {
      var att = new adm_Attachment();
      att = this.state.SelectedDefault;
      att.FileContent = result.base64;

      if (result.uri.toString() != "") {
        let uriArray = result.uri.toString().split("/");
        if (uriArray.length > 0) {
          let filename = uriArray[uriArray.length - 1];
          att.FILE_NAME = filename;
          att.DISPLAY_NAME = filename;

          let fileExternal = filename.split(".")[1];

          att.FILE_CONTENT_TYPE = "image/" + fileExternal;
        }
      }

      // upload ảnh
      ImageManipulator.manipulateAsync(
        result.uri,
        [{ resize: { width: result.width / 2, height: result.height / 2 } }],
        {
          compress: 0.8,
          base64: true,
        }
      )
        .then((result) => {
          att.FileContent = result.base64;
          this.saveImage(att);
        })
        .catch((e) => {
          this.saveImage(att);
        });

      this.setState({ LoaddingIndexShow: -1 });
      let mess = "Tải ảnh thành công!";
      this.props.GlobalStore.Exception = ClientMessage(mess);
    } catch (ex) {
      this.setState({ LoaddingIndexShow: -1 });
      this.props.GlobalStore.Exception = ex;
    }
  };

  //Chụp ảnh sơ đồ vệ tinh trực tiếp
  _pickImageSDVTCamera = async (type: number) => {
    try {
      let { status } = await Permissions.getAsync(
        Permissions.CAMERA,
        Permissions.CAMERA_ROLL
      );

      if (status !== "granted") {
        //@ts-ignore
        let status1 = await (
          await Permissions.askAsync(
            Permissions.CAMERA,
            Permissions.CAMERA_ROLL
          )
        ).status;

        if (status1 !== "granted") {
          return;
        }
      }

      this.timerId = setInterval(() => {
        clearInterval(this.timerId);
        this.setState({
          showLoaddingImageSDVT: type == Enums.UploadPopupType.SoDoVeTinh ? true : false,
          showLoaddingImageSDQH: type == Enums.UploadPopupType.SoDoQuyHoach ? true : false,
        });
      }, 1000);

      let result: any = await ImagePicker.launchCameraAsync({
        mediaTypes: ImagePicker.MediaTypeOptions.Images,
        quality: 0.8,
        allowsEditing: false,
        base64: true,
      });

      if (!result.cancelled) {
        this._handleImagePickedSDVT(type, result);
      } else {
        this.setState({
          showLoaddingImageSDVT: false,
          showLoaddingImageSDQH: false,
        });
      }
    } catch (ex) {
      this.setState({
        showLoaddingImageSDVT: false,
        showLoaddingImageSDQH: false,
      });
      this.props.GlobalStore.Exception = ex;
    }
  };

  //Tải ảnh sơ đồ vệ tinh từ thư viện
  _pickImageSDVT = async (type: number) => {
    try {

      this.timerId = setInterval(() => {
        clearInterval(this.timerId);
        this.setState({
          showLoaddingImageSDVT: type == Enums.UploadPopupType.SoDoVeTinh ? true : false,
          showLoaddingImageSDQH: type == Enums.UploadPopupType.SoDoQuyHoach ? true : false,
        });
      }, 1000);

      let result = await ImagePicker.launchImageLibraryAsync({
        mediaTypes: ImagePicker.MediaTypeOptions.Images,
        base64: true,
        quality: 0.8,
      });
      if (!result.cancelled) {
        this._handleImagePickedSDVT(type, result);
      } else {
        this.setState({
          showLoaddingImageSDVT: false,
          showLoaddingImageSDQH: false,
        });
      }
    } catch (ex) {
      this.setState({
        showLoaddingImageSDVT: false,
        showLoaddingImageSDQH: false,
      });
      this.props.GlobalStore.Exception = ex;
    }
  };

  _handleImagePickedSDVT = async (type, result) => {
    try {
      this.setState({
        SelectedImageInFlatList: false,
        showLoaddingImageSDVT: this.state.LoaddingImageSDVT,
      });
      var req = new AttachmentDto();
      var att = new adm_Attachment();

      if (result.cancelled) return;
      //att.ImageBase64String = result.base64;
      att.FileContent = result.base64;
      this.props.Images.forEach((element) => {
        (att.REF_ID = element.REF_ID), (att.REF_TYPE = Enums.AttachmentRefType.ProcessValuationDocumentOfMA);
      });

      if (result.uri.toString() != "") {
        let uriArray = result.uri.toString().split("/");
        if (uriArray.length > 0) {
          let filename = uriArray[uriArray.length - 1];
          att.FILE_NAME = filename;
          att.DISPLAY_NAME = filename;
          if (type == Enums.UploadPopupType.SoDoQuyHoach) {
            att.REF_CODE_CODE = "SoDoQuyHoach";
          }
          if (type == Enums.UploadPopupType.SoDoVeTinh) {
            att.REF_CODE_CODE = "SoDoVeTinh";
          }
          let fileExternal = filename.split(".")[1];

          att.FILE_CONTENT_TYPE = "image/" + fileExternal;
        }
      }

      // upload ảnh
      ImageManipulator.manipulateAsync(
        result.uri,
        [{ resize: { width: result.width / 2, height: result.height / 2 } }],
        {
          compress: 0.8,
          base64: true,
        }
      )
        .then((result) => {
          att.FileContent = result.base64;
        })
        .catch((e) => { });

      req.Attachment = att;
      let res = await HttpUtils.post<AttachmentDto>(
        ApiUrl.Attachment_Execute,
        SMX.ApiActionCode.UploadImage,
        JSON.stringify(req)
      );
      if (res) {
        //Check ko load lai ảnh trong flatlList nữa
        this.props.GlobalStore.ImageChangedInFlatList =
          this.state.SelectedImageInFlatList;
        //Gán ảnh sơ đồ vệ tinh mới vào GlobalStore
        this.props.GlobalStore.ImageValueUpdatedSDVT = res.Attachment;
      }

      this.props.GlobalStore.UpdateImageTrigger();
      this.setState({
        showLoaddingImageSDVT: false,
      });
      let message = "Upload thành công!";
      this.props.GlobalStore.Exception = ClientMessage(message);
    } catch (ex) {
      this.props.GlobalStore.HideLoading();
      this.props.GlobalStore.Exception = ex;
    }
  };

  showPopUp = async () => {
    this.setState({ showPopUp: false });
  };

  renderImage(image: adm_Attachment, index: number) {
    return (
      <View>
        <TouchableOpacity
          onPress={() => {
            if (image.FileContent != null) {
              this.setState({
                SelectedFullScreen: image,
                SelectedImageInFlatList: true,
              });
            } else {
              this.setState({ SelectedDefault: image });
              this.setState({
                LoaddingIndexSelected: index,
                showPopUp: true,
                uploadType: Enums.UploadPopupType.HienTrang,
              });
            }
          }}
        >
          {index == this.state.LoaddingIndexShow ? (
            <View
              style={{
                position: "absolute",
                flex: 1,
                zIndex: 999999999,
                left: (width / this.props.numberColumn - 19) / 2,
                right: (width / this.props.numberColumn - 19) / 2,
                bottom: (width / this.props.numberColumn - 19) / 2,
              }}
            >
              <ActivityIndicator size="large" color={SMX.TextColorABB} />
            </View>
          ) : undefined}
          {image.FileContent != null ? (
            <Image
              source={{
                uri: "data:image/png;base64," + image.FileContent,
              }}
              style={{
                borderRadius: 8,
                margin: 5,
                width: width / this.props.numberColumn - 19,
                height: width / this.props.numberColumn - 19,
                resizeMode: "cover",
              }}
            />
          ) : (
            <Image
              source={require("../../assets/notfound.png")}
              style={{
                borderRadius: 8,
                margin: 5,
                width: width / this.props.numberColumn - 19,
                height: width / this.props.numberColumn - 19,
                resizeMode: "cover",
                borderColor: "#F0F0F4",
                borderWidth: 1,
              }}
            />
          )}
        </TouchableOpacity>
        <View
          style={{
            flexDirection: "row",
            width: width / this.props.numberColumn - 19,
            justifyContent: "center",
            alignItems: "center",
            paddingBottom: 5,
          }}
        >
          <Text
            style={{
              fontWeight: "bold",
              color: "#1C4694",
              width: width / this.props.numberColumn - 19,
              textAlign: "center",
              fontSize: 12,
            }}
          >
            {image.DOCUMENT_NAME}
          </Text>
        </View>
      </View>
    );
  }

  isInitPage: boolean = true;
  render() {
    // Ẩn layout khi chưa setup form
    if (this.isInitPage === true) {
      this.isInitPage = false;
      return <></>;
    }
    return (
      <View
        style={{
          flex: 1,
          backgroundColor: "#FFFFFF",
          borderColor: "#7ba6c2",
          borderRadius: 5,
          borderWidth: 1,
          marginVertical: 8,
          paddingVertical: 12,
        }}
      >
        {this.props.IsHasSoDoVeTinh == true ? (
          <View>
            <TouchableOpacity
              onPress={() => {
                if (this.props.AttachmentSoDoVeTinh.FileContent != null) {
                  this.setState({
                    SelectedFullScreen: this.props.AttachmentSoDoVeTinh,
                    SelectedImageInFlatList: false,
                    LoaddingImageSDVT: true,
                  });
                } else {
                  this.setState({
                    SelectedImageInFlatList: false,
                    LoaddingImageSDVT: true,
                    SelectedDefault: this.props.AttachmentSoDoVeTinh,
                    showPopUp: true,
                    uploadType: Enums.UploadPopupType.SoDoVeTinh,
                  });
                }
              }}
            >
              {this.state.showLoaddingImageSDVT ? (
                <View
                  style={{
                    position: "absolute",
                    flex: 1,
                    zIndex: 999999999,
                    right: (width - 28) / 2,
                    bottom: (width / this.props.numberColumn - 19) / 2,
                  }}
                >
                  <ActivityIndicator size="large" color={SMX.TextColorABB} />
                </View>
              ) : undefined}

              {this.props.AttachmentSoDoVeTinh.FileContent != null ? (
                <Image
                  source={{
                    uri:
                      "data:image/png;base64," +
                      this.props.AttachmentSoDoVeTinh.FileContent,
                  }}
                  style={{
                    borderRadius: 8,
                    margin: 5,
                    width: width - 28,
                    height: width / this.props.numberColumn - 19,
                    resizeMode: "cover",
                  }}
                />
              ) : (
                <Image
                  source={require("../../assets/notfound.png")}
                  style={{
                    borderRadius: 8,
                    margin: 5,
                    width: width - 28,
                    height: width / this.props.numberColumn - 19,
                    resizeMode: "cover",
                  }}
                />
              )}
            </TouchableOpacity>
            <Text
              style={{
                fontWeight: "bold",
                color: "#1C4694",
                textAlign: "center",
              }}
            >
              Sơ đồ vệ tinh
            </Text>
          </View>
        ) : undefined}

        {this.props.IsHasSoDoQuyHoach == true ? (
          <View>
            <TouchableOpacity
              onPress={() => {
                if (this.props.AttachmentSoDoQuyHoach.FileContent != null) {
                  this.setState({
                    SelectedFullScreen: this.props.AttachmentSoDoQuyHoach,
                  });
                } else {
                  this.setState({
                    SelectedDefault: this.props.AttachmentSoDoQuyHoach,
                    showPopUp: true,
                    uploadType: Enums.UploadPopupType.SoDoQuyHoach,
                  });
                }
              }}
            >
              {this.state.showLoaddingImageSDQH ? (
                <View
                  style={{
                    position: "absolute",
                    flex: 1,
                    justifyContent: "center",
                    alignItems: "center",
                    zIndex: 999999999,
                  }}
                >
                  <ActivityIndicator size="large" color={SMX.TextColorABB} />
                </View>
              ) : undefined}
              {this.props.AttachmentSoDoQuyHoach.FileContent != null ? (
                <Image
                  source={{
                    uri:
                      "data:image/png;base64," +
                      this.props.AttachmentSoDoQuyHoach.FileContent,
                  }}
                  style={{
                    borderRadius: 8,
                    margin: 5,
                    width: width - 28,
                    height: width / this.props.numberColumn - 19,
                    resizeMode: "cover",
                  }}
                />
              ) : (
                <Image
                  source={require("../../assets/notfound.png")}
                  style={{
                    borderRadius: 8,
                    width: width - 28,
                    height: width / this.props.numberColumn - 19,
                    resizeMode: "cover",
                  }}
                />
              )}
              <Text
                style={{
                  fontWeight: "bold",
                  color: "#1C4694",
                  textAlign: "center",
                }}
              >
                Sơ đồ quy hoạch
              </Text>
            </TouchableOpacity>
          </View>
        ) : undefined}

        <FlatList
          data={this.props.Images}
          numColumns={this.props.numberColumn}
          renderItem={({ item, index }) => this.renderImage(item, index)}
          keyExtractor={(item, index) => index.toString()}
        />

        <PopUpModalABB
          resetState={this.showPopUp}
          modalVisible={this.state.showPopUp}
          title="Upload ảnh"
        >
          <View
            style={{
              flexDirection: "column",
              paddingBottom: 6,
              marginLeft: 10,
            }}
          >
            <TouchableOpacity
              onPress={() => {
                switch (this.state.uploadType) {
                  case Enums.UploadPopupType.SoDoVeTinh: {
                    this.setState({ showPopUp: false },
                      () => {
                        setTimeout(() => {
                          this._pickImageSDVTCamera(
                            Enums.UploadPopupType.SoDoVeTinh
                          );
                        }, 500);
                      }
                    );
                    break;
                  }
                  case Enums.UploadPopupType.SoDoQuyHoach: {
                    this.setState({ showPopUp: false },
                      () => {
                        setTimeout(() => {
                          this._pickImageSDVTCamera(
                            Enums.UploadPopupType.SoDoQuyHoach
                          );
                        }, 500);
                      }
                    );
                    break;
                  }
                  case Enums.UploadPopupType.HienTrang: {
                    this.setState({ showPopUp: false },
                      () => {
                        setTimeout(() => {
                          this._pickImageCamera();
                        }, 500);
                      }
                    );
                    break;
                  }
                }
              }}
            >
              <View
                style={{
                  flex: 2,
                  flexDirection: "row",
                  marginLeft: 10,
                }}
              >
                <View style={{ marginTop: 5 }}>
                  <FontAwesome5 name="camera" size={18} color={SMX.TextColorABB} />
                </View>
                <Text style={styles.title}>Chụp ảnh</Text>
              </View>
            </TouchableOpacity>
            <View
              style={{
                height: 1,
                backgroundColor: "#F0F0F4",
                marginVertical: 8,
              }}
            />
            <View>
              <TouchableOpacity
                style={{
                  paddingBottom: 8,
                }}
                onPress={() => {
                  switch (this.state.uploadType) {
                    case Enums.UploadPopupType.SoDoVeTinh: {
                      this.setState(
                        { showPopUp: false },
                        () => {
                          setTimeout(() => {
                            this._pickImageSDVT(
                              Enums.UploadPopupType.SoDoVeTinh
                            );
                          }, 500);
                        }
                      );
                      break;
                    }
                    case Enums.UploadPopupType.SoDoQuyHoach: {
                      this.setState(
                        { showPopUp: false },
                        () => {
                          setTimeout(() => {
                            this._pickImageSDVT(
                              Enums.UploadPopupType.SoDoQuyHoach
                            );
                          }, 500);
                        }
                      );
                      break;
                    }
                    case Enums.UploadPopupType.HienTrang: {
                      this.setState({ showPopUp: false },
                        () => {
                          setTimeout(() => {
                            this._pickImage();
                          }, 500);
                        }
                      );
                      break;
                    }
                  }
                }}
              >
                <View style={{ flex: 2, flexDirection: "row", marginLeft: 10 }}>
                  <View style={{ marginTop: 5 }}>
                    <FontAwesome5 name="images" size={18} color={SMX.TextColorABB} />
                  </View>
                  <Text style={styles.title}>Thư viện ảnh</Text>
                </View>
              </TouchableOpacity>
            </View>
          </View>
        </PopUpModalABB>

        {this.state.SelectedFullScreen != null ? (
          <Modal visible={true}>
            <ImageViewer
              imageUrls={[
                {
                  url:
                    "data:image/png;base64," +
                    this.state.SelectedFullScreen.FileContent,
                },
              ]}
              backgroundColor={"white"}
              renderIndicator={() => null}
            />
            <View
              style={{
                position: "absolute",
                zIndex: 999999999,
                justifyContent: "space-around",
                alignItems: "center",
                flexDirection: "row",
                marginTop: 30,
                flex: 1
              }}
            >
              <TouchableOpacity
                //@ts-ignore
                style={{
                  justifyContent: "space-around",
                  alignItems: "center",
                  backgroundColor: SMX.TextColorABB,
                  height: 40,
                  marginLeft: 15,
                  padding: 10,
                  borderRadius: 50,
                }}
                onPress={() =>
                  this.setState({
                    SelectedFullScreen: null,
                    SelectedImageInFlatList: false,
                  })
                }
              >
                <View style={{ flexDirection: "row", alignItems: "center" }}>
                  <FontAwesome5 name="arrow-left" size={20} color={"white"} />
                  <Text
                    style={{
                      fontWeight: "bold",
                      fontSize: 15,
                      marginLeft: 15,
                      color: "white",
                    }}
                  >
                    Back
                  </Text>
                </View>
              </TouchableOpacity>
              {this.props.allowEdit != null && this.props.allowEdit ? (
                <TouchableOpacity
                  //@ts-ignore
                  style={{
                    backgroundColor: SMX.TextColorABB,
                    justifyContent: "center",
                    alignItems: "center",
                    height: 40,
                    marginLeft: 15,
                    padding: 10,
                    borderRadius: 50,
                  }}
                  onPress={() => this.handleEdit(this.state.SelectedFullScreen)}
                >
                  <View style={{ flexDirection: "row", alignItems: "center" }}>
                    <FontAwesome5 name="edit" size={20} color={"white"} />
                    <Text
                      style={{
                        fontWeight: "bold",
                        fontSize: 15,
                        marginLeft: 15,
                        color: "white",
                      }}
                    >
                      Sửa
                    </Text>
                  </View>
                </TouchableOpacity>
              ) : undefined}
              {this.props.allowRemove != null && this.props.allowRemove ? (
                <TouchableOpacity
                  //@ts-ignore
                  style={{
                    backgroundColor: SMX.TextColorABB,
                    justifyContent: "center",
                    alignItems: "center",
                    height: 40,
                    marginLeft: 15,
                    padding: 10,
                    borderRadius: 50,
                  }}
                  onPress={() => {
                    this.handleRemove(this.state.SelectedFullScreen);
                  }}
                >
                  <View style={{ flexDirection: "row", alignItems: "center" }}>
                    <FontAwesome5 name="trash" size={20} color={"white"} />
                    <Text
                      style={{
                        fontWeight: "bold",
                        fontSize: 15,
                        marginLeft: 15,
                        color: "white",
                      }}
                    >
                      Xóa
                    </Text>
                  </View>
                </TouchableOpacity>
              ) : undefined}
            </View>
          </Modal>
        ) : undefined}
      </View>
    );
  }
}

const styles = StyleSheet.create({
  title: {
    paddingLeft: 8,
    paddingTop: 5,
    textAlign: "center",
    color: SMX.TextColorABB,
    fontWeight: "600",
  },
});
